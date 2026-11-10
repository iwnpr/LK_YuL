using application_lib.Entities;
using application_lib.Entities.Enums;
using application_lib.Entities.Records;
using application_lib.Entities.XML.CreditReport.Request;
using application_lib.Entities.XML.QBCH;
using bureau_data_lib;
using legal_persons_lib.Entities;
using legal_persons_lib.Entities.Requests;
using legal_persons_lib.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Xml.Linq;

namespace application_lib.Services
{
    public interface IRequestManager
    {
        Task<T?> GetAsync<T>(int _id, int _user, bool _showAll) where T : DBRequest;

        Task<List<RequestRecord>> GetListAsync<T>(int _userId, int _skip, bool _show);

        Task<Answer> UpdateAsync<T>(T _request);

        Task<Answer> InsertAsync<T>(T _request);

        Task<Answer> SendRequestAsync<T>(T _request) where T : DBRequest;

        /// <summary>
        /// Получение информации о договоре по UID
        /// </summary>
        /// <param name="_request"></param>
        /// <returns></returns>
        Task<Answer> GetResultFromStoredProcedure(DBRequestCheckContractsByUser _request);

        Request CreateRequest(bool _isNaturalSubject, DBOrganization _organization);

        RequestAMP CreateRequestQBCH(DBOrganization _organization);
    }

    public class RequestManager : IRequestManager
    {
        private readonly IRepository<DBRequestCheckContractsByUser> _requestsCheckContracts;
        private readonly IRepository<DBRequestForGovernmentByUser> _requestsForGovenment;
        private readonly IRepository<DBRequestOfBureau> _requestsOfBureau;
        private readonly IRepository<DBRequestOfQBCH> _requestsOfQBCH;
        private readonly IRepository<DBUser> _users;
        private readonly IRepository<DBOrganization> _organizations;
        private readonly ISender _sender;
        private readonly IConfiguration _configuration;
        private readonly IDbContextFactory<BureauDataContext> _bureauDataFactory;

        public RequestManager(IConfiguration configuration,
            IRepository<DBRequestCheckContractsByUser> requestsCheckContracts,
            IRepository<DBUser> users,
            ISender sender,
            IRepository<DBRequestForGovernmentByUser> requestsForGovenment,
            IRepository<DBRequestOfBureau> requestsOfBureau,
            IRepository<DBOrganization> organizations,
            IDbContextFactory<BureauDataContext> bureauDataFactory,
            IRepository<DBRequestOfQBCH> requestsOfQBCH)
        {
            _requestsCheckContracts = requestsCheckContracts;
            _users = users;
            _sender = sender;
            _configuration = configuration;
            _requestsForGovenment = requestsForGovenment;
            _requestsOfBureau = requestsOfBureau;
            _organizations = organizations;
            _bureauDataFactory = bureauDataFactory;
            _requestsOfQBCH = requestsOfQBCH;
        }


        /// <inheritdoc/>
        public Request CreateRequest(bool _isNaturalPerson, DBOrganization _organization)
        {
            return new Request()
            {
                Header = new()
                {
                    User = new()
                    {
                        UserId = _organization.LegalPersonId.ToString(),
                        UserCode = _organization.OrganizationTypeId.ToString(),
                        UserLegalEntity = new()
                        {
                            RegisteredInRf = 1,
                            UserName = new()
                            {
                                FullName = _organization.FullName,
                                ShortName = _organization.ShortName
                            },
                            UserITN = new()
                            {
                                ItnCode = "1",
                                Itn = _organization.Itn
                            },
                            UserPSRN = new()
                            {
                                PSRN = _organization.Psrn,
                                PSRNCode = "1"
                            }
                        }
                    },
                    RequestDate = DateTime.Now.ToString("dd.MM.yyyy")
                },
                Body = new()
                {
                    NaturalPersonSubject =
                        _isNaturalPerson
                        ? new()
                        {
                            Title = new()
                            {
                                LastName = "",
                                FirstName = "",
                                MiddleName = ""

                            },
                            BirthDate = "",
                            IdentificationDocuments = new()
                                                        {
                            new()
                            {
                                DocTypeID = "21",
                                DocSer = "",
                                DocNum = "",
                                DocDate = "",
                                DocDelivInstCode = "",
                                DocDelivInstName = ""
                            }
                                                        }
                        }
                        : null,
                    LegalPersonSubject = !_isNaturalPerson
                        ? new()
                        {
                            Title = new()
                            {
                                Name = new()
                                {
                                }
                            }

                        }
                        : null
                }
            };
        }

        /// <inheritdoc/>
        public async Task<T?> GetAsync<T>(int _id, int _user, bool _showAll) where T : DBRequest
        {
            return typeof(T).Name switch
            {
                "DBRequestCheckContractsByUser" => (T)Convert.ChangeType(await _requestsCheckContracts.GetSingleAsync(r => r.Id.Equals(_id) && (r.UserId.Equals(_user) || _showAll)), typeof(T))!,
                "DBRequestForGovernmentByUser" => (T)Convert.ChangeType(await _requestsForGovenment.GetSingleAsync(r => r.Id.Equals(_id) && (r.UserId.Equals(_user) || _showAll)), typeof(T))!,
                "DBRequestOfBureau" => (T)Convert.ChangeType(await _requestsOfBureau.GetSingleAsync(r => r.Id.Equals(_id) && (r.UserId.Equals(_user) || _showAll)), typeof(T))!,
                "DBRequestOfQBCH" => (T)Convert.ChangeType(await _requestsOfQBCH.GetSingleAsync(r => r.Id.Equals(_id) && (r.UserId.Equals(_user) || _showAll)), typeof(T))!,
                _ => null
            };

        }

        private record RequestUser
        {
            public int Id { get; set; }
            public string ShortName { get; set; } = string.Empty;
            public string UserName { get; set; } = string.Empty;
        }

        /// <inheritdoc/>
        public async Task<List<RequestRecord>> GetListAsync<T>(int _userId, int _page, bool _show)
        {
            var user = await _users.GetAsync(_userId, "Organization");
            var _orgs = await _organizations.GetListAsync();

            var _list = (await _users.GetListAsync())
                .Join(_orgs, u => u.OrganizationId, o => o.Id, (u, o) =>
                new RequestUser { Id = u.Id, ShortName = o.ShortName, UserName = $"{u.LastName} {u.FirstName}" }).ToList();
            ;


            return typeof(T).Name switch
            {
                "DBRequestCheckContractsByUser" =>
                    (await _requestsCheckContracts.GetListAsync(req => req.UserId.Equals(_userId) || _show, _page * 20, 20))
                    .Join(_list, r => r.UserId, u => u.Id, (r, u) =>
                        new RequestRecord(r.Id, r.Inserted, r.Request, string.IsNullOrEmpty(r.Response)
                                    ? RequestStatus.in_process
                                    : XDocument.Parse(r.Response).Descendants("error").Any()
                                        ? RequestStatus.error
                                        : (XDocument.Parse(r.Response).Descendants("credit-contract").Any() || XDocument.Parse(r.Response).Descendants("CreditContractRecord").Descendants().Any()
                                            || XDocument.Parse(r.Response).Descendants("CreditRecord").Descendants().Any())
                                            ? RequestStatus.done
                                            : RequestStatus.attention, u.ShortName, u.UserName))
                            .ToList() ?? new(),
                "DBRequestForGovernmentByUser" =>
                    (await _requestsForGovenment.GetListAsync(req => req.UserId.Equals(_userId) || _show, _page * 20, 20))
                    .Join(_list, r => r.UserId, u => u.Id, (r, u) => new RequestRecord(r.Id, r.Inserted, r.Request, string.IsNullOrEmpty(r.Response)
                                    ? RequestStatus.in_process
                                    : XDocument.Parse(r.Response).Descendants("error").Any()
                                        ? RequestStatus.error
                                        : XDocument.Parse(r.Response).Descendants("Pdf")?.FirstOrDefault()?.Attribute("status")?.Value?.Equals("1") ?? false
                                            ? RequestStatus.done
                                            : RequestStatus.attention, user!.Organization.ShortName, $"{user.LastName} {user.FirstName}")).ToList() ?? new(),
                "DBRequestOfBureau" =>
                    (await _requestsOfBureau.GetListAsync(req => req.UserId.Equals(_userId) || _show, _page * 20, 20))
                    .Join(_list, r => r.UserId, u => u.Id, (r, u) =>
                        new RequestRecord(r.Id, r.Inserted, r.Request, r.Status.Equals(0)
                                    ? RequestStatus.in_process
                                    : r.Status.Equals(3)
                                        ? RequestStatus.error
                                        : r.Status.Equals(2)
                                            ? RequestStatus.attention
                                            : RequestStatus.done, u!.ShortName, u.UserName))
                            .ToList() ?? new(),
                "DBRequestOfQBCH" =>
                                    (await _requestsOfQBCH.GetListAsync(req => req.UserId.Equals(_userId) || _show, _page * 20, 20))
                                    .Join(_list, r => r.UserId, u => u.Id, (r, u) =>
                                        new RequestRecord(r.Id, r.Inserted, r.Request, r.Status.Equals(0)
                                            ? RequestStatus.in_process
                                            : r.Status.Equals(3)
                                                ? RequestStatus.error
                                                : r.Status.Equals(2)
                                                    ? RequestStatus.attention
                                                    : RequestStatus.done, u!.ShortName, u.UserName))
                                               .ToList() ?? new(),
                _ => new()
            };
        }

        /// <inheritdoc/>
        public async Task<Answer> InsertAsync<T>(T _request)
        {
            if (_request is null) return new Answer(-1, "Запрос не должен быть пустым");

            return typeof(T).Name switch
            {
                "DBRequestCheckContractsByUser" =>
                    await _requestsCheckContracts.InsertAsync((_request! as DBRequestCheckContractsByUser)!) ? new Answer(200, "Запрос отправлен!") : new Answer(-1, "Не удалось отправить запрос!"),
                "DBRequestForGovernmentByUser" =>
                    await _requestsForGovenment.InsertAsync((_request! as DBRequestForGovernmentByUser)!) ? new Answer(200, "Запрос отправлен!") : new Answer(-1, "Не удалось отправить запрос!"),
                "DBRequestOfBureau" =>
                    await _requestsOfBureau.InsertAsync((_request! as DBRequestOfBureau)!) ? new Answer(200, "Запрос отправлен!") : new Answer(-1, "Не удалось отправить запрос!"),
                "DBRequestOfQBCH" =>
                                    await _requestsOfQBCH.InsertAsync((_request! as DBRequestOfQBCH)!) ? new Answer(200, "Запрос отправлен!") : new Answer(-1, "Не удалось отправить запрос!"),
                _ => new Answer(-1, "Ошибка обработки запроса!")
            };
        }

        /// <inheritdoc/>
        public async Task<Answer> SendRequestAsync<T>(T _request) where T : DBRequest
        {
            string _url = typeof(T).Name switch
            {
                "DBRequestCheckContractsByUser" => $"{_configuration.GetSection("Links:CreditData").Value}/report/getxmlcreditreport",
                "DBRequestForGovernmentByUser" => $"{_configuration.GetSection("Links:CreditData").Value}/Report/GetBase64CreditReport",
                "DBRequestOfBureau" => $"{_configuration.GetSection("Links:A2A").Value}",
                _ => ""
            };

            Answer _answer = new(200, string.Empty);

            if (typeof(T).Name.Equals("DBRequestCheckContractsByUser"))
            {
                _answer = !_request.Request.Contains("Uid")
                    ? await _sender.SendStringAsync(_url, "POST", _request.Request)
                    : await GetResultFromStoredProcedure((_request as DBRequestCheckContractsByUser)!);

                if (!_answer.Code.Equals(200))
                {
                    _request.Response = $"<response><error>{_answer.Message}</error></response>";
                    return _answer;
                }

                XDocument _response = XDocument.Parse(_answer.Message);

                var _legal = (await _users.GetSingleAsync(_item => _item.Id.Equals(_request.UserId), "Organization"))!.Organization.LegalPersonId.ToString();

                //Если запрос не от КредитИнфо, то удаляем записи не от источника
                /*if (!_request.OrganizationId.Equals(1))
                {
                    _response.Descendants("CreditContractRecord")?
                    .Where(c => !c.Attribute("OwnerID")?.Value.Equals(_legal) ?? false)?.Remove();
                }*/

                if (!_request.OrganizationId.Equals(1))
                {
                    _response.Descendants("CreditRecord")?
                    .Where(c => !c.Attribute("ownerId")?.Value.Equals(_legal) ?? false)?.Remove();
                }

                /*if (!_request.Request.Contains("Uid"))
                {
                    _response = _response.Descendants("CreditContractRecord").Any() ? new(new XElement("Report", _response.Descendants("CreditContractRecord"))) : new(new XElement("Report"));
                }*/

                if (!_request.Request.Contains("Uid"))
                {
                    _response = _response.Descendants("CreditRecord").Any() ? new(new XElement("Report", _response.Descendants("CreditRecord"))) : new(new XElement("Report"));
                }

                _request.Response = _response.ToString();
            }

            if (typeof(T).Name.Equals("DBRequestForGovernmentByUser"))
            {
                _answer = await _sender.SendStringAsync(_url, "POST", _request.Request);

                if (!_answer.Code.Equals(200))
                {
                    _request.Response = $"<RESPONSE version=\"05.00\"><Error>{_answer.Message}</Error></RESPONSE>";
                    //await InsertAsync(_request);
                    return _answer;
                }

                _request.Response = _answer.Message;
            }

            if (typeof(T).Name.Equals("DBRequestOfBureau"))
            {
                //_answer = await _sender.SendPostRequestWithHeaderAsync(_url, _creditionals!,_request.Request);
                _answer = await _sender.SendStringAsync(_url, "POST", _request.Request);

                if (!_answer.Code.Equals(200))
                {
                    _request.Response = $"<RESPONSE version=\"05.00\"><Error>{_answer.Message}</Error></RESPONSE>";
                    //await InsertAsync(_request);
                    return _answer;
                }

                _request.Response = _answer.Message;
                (_request as DBRequestOfBureau)!.Updated = DateTime.Now;

                XDocument _response = XDocument.Parse(_request.Response);

                (_request as DBRequestOfBureau)!.Status = _response.Descendants("Error").Any() ? 3 : _response.Descendants("Warning").Any() ? 2 : 1;

                long.TryParse(_response.Descendants("ResponseID")?.FirstOrDefault()?.Value, out var _responseId);

                (_request as DBRequestOfBureau)!.ResponseId = _responseId;
            }

            _answer = await InsertAsync(_request);

            return _answer;
        }

        /// <inheritdoc/>
        public async Task<Answer> UpdateAsync<T>(T _request)
        {
            if (_request is null) return new Answer(-1, "Запрос не должен быть пустым");

            return typeof(T).Name switch
            {
                "DBRequestCheckContractsByUser" =>
                    await _requestsCheckContracts.UpdateAsync((_request! as DBRequestCheckContractsByUser)!) ? new Answer(200, "Запрос отправлен!") : new Answer(-1, "Не удалось отправить запрос!"),
                "DBRequestForGovernmentByUser" =>
                    await _requestsForGovenment.UpdateAsync((_request! as DBRequestForGovernmentByUser)!) ? new Answer(200, "Запрос отправлен!") : new Answer(-1, "Не удалось отправить запрос!"),
                "DBRequestOfBureau" =>
                    await _requestsOfBureau.UpdateAsync((_request! as DBRequestOfBureau)!) ? new Answer(200, "Запрос отправлен!") : new Answer(-1, "Не удалось отправить запрос!"),
                _ => new Answer(-1, "Ошибка обработки запроса!")
            };
        }

        public async Task<Answer> GetResultFromStoredProcedure(DBRequestCheckContractsByUser _request)
        {
            Request _entity = _request.Request.Deserialize<Request>();

            try
            {
                await using var bureauData = await _bureauDataFactory.CreateDbContextAsync();
                bureauData.Database.SetCommandTimeout(TimeSpan.FromMinutes(5));

                CreditRecord? _result = (await bureauData.Results.FromSqlRaw($"SELECT {_configuration.GetSection("Procedures:CreditContractCheck").Value}('{_entity.Body.Contract!.Uid}', {_entity.Body.Contract!.LegalPersonId}) as xml").ToListAsync())?.FirstOrDefault();
                
                if (_result?.Xml is not null && XElement.Parse(_result.Xml).Descendants().Any())
                    return new(200, _result.Xml);
            }
            catch 
            {
                return new(-1, "Ошибка проверки договора");
            }

            return new(200, "<Empty />"); ;
        }

        public RequestAMP CreateRequestQBCH(DBOrganization _organization) =>
            new()
            {
                RequestDate = DateTime.Now.ToString("yyyy-MM-dd"),
                Abonent = new()
                {
                    LegalEntity = !_organization.OrganizationTypeId.Equals(1) ? new()
                    {
                        TaxpayerIdentificationNumber = _organization.Itn,
                        PrimaryStateRegister = _organization.Psrn,
                        RegisterInRF = string.Empty
                    } : null,
                    IndividualEntrepreneur = _organization.OrganizationTypeId.Equals(1) ? new()
                    {
                        TaxpayerIdentificationNumber = _organization.Itn,
                        PrimaryStateRegister = _organization.Psrn,
                        RegisterInRF = string.Empty
                    } : null,

                },
                Request = new()
                {
                    Source = new()
                    {
                        SourceLegalEntity = !_organization.OrganizationTypeId.Equals(1) ? new()
                        {
                            FullName = _organization.FullName.Replace("«", "\"").Replace("»", "\""),
                            ShortName = _organization.ShortName.Replace("«", "\"").Replace("»", "\""),
                            PrimaryStateRegister = _organization.Psrn,
                            TaxpayerIdentificationNumber = _organization.Itn,
                            TypeCode = _organization.OrganizationTypeId.ToString()
                        } : null,
                        SourceIndividualEntrepreneur = _organization.OrganizationTypeId.Equals(1) ? new()
                        {
                            FullName = _organization.FullName.Replace("«", "\"").Replace("»", "\""),
                            ShortName = _organization.ShortName.Replace("«", "\"").Replace("»", "\""),
                            PrimaryStateRegister = _organization.Psrn,
                            TaxpayerIdentificationNumber = _organization.Itn,
                            TypeCode = _organization.OrganizationTypeId.ToString()
                        } : null,
                    },
                    Consent = new()
                    {
                        ConsentDate = DateTime.Now.ToShortDateString(),
                        ConsentExpiration = "1",
                        HashCode = "",
                        IsWarned = "1",
                        Purpose = new()
                        {
                            Code = "1",
                            Description = string.Empty
                        },
                        Issued = new()
                        {
                            IssuedLegalEntity = !_organization.OrganizationTypeId.Equals(1) ? new()
                            {
                                FullName = _organization.FullName.Replace("«", "\"").Replace("»", "\""),
                                ShortName = string.Empty,
                                PrimaryStateRegister = _organization.Psrn,
                                TaxpayerIdentificationNumber = _organization.Itn,
                                RegisterInRF = string.Empty
                            } : null,
                            IssuedIndividualEntrepreneur = _organization.OrganizationTypeId.Equals(1) ? new()
                            {
                                FullName = _organization.FullName.Replace("«", "\"").Replace("»", "\""),
                                ShortName = string.Empty,
                                PrimaryStateRegister = _organization.Psrn,
                                TaxpayerIdentificationNumber = _organization.Itn,
                                RegisterInRF = string.Empty
                            } : null
                        }
                    },
                    Purpose = new()
                    { 
                        Code = "1",
                        Description = string.Empty
                    },
                    Amount= new()
                    {
                        Text = string.Empty,
                        Currency = "RUB"
                    }
                },
                RequestId = Guid.NewGuid().ToString(),
                RequestType = "2"
            };

        
    }

}
