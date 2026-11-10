using System.Globalization;
using System.Reflection;
using System.Xml.Serialization;
using application_lib.Entities.XML.A2A.V1100.Request;
using application_lib.Services;
using legal_persons_lib.Entities;
using user_interface_private_web.Entities;
using SavedResponseCapabilities = application_lib.Entities.XML.CreditReport.Request.RequestResponseCapabilities;
using XmlRequest = application_lib.Entities.XML.A2A.V1100.Request.Request;

namespace user_interface_private_web.Pages.Requests.RequestOfBureau;

public sealed record BureauRequestBuildResult(string Xml, bool RequiresSignature);

public interface IBureauRequestXmlBuilder
{
    BureauRequestBuildResult Build(
        BureauRequestModel model,
        ParametersBureau parameters,
        DBOrganization organization);

    ParametersBureau DeserializeParameters(string xml);
}

internal sealed class BureauRequestXmlBuilder : IBureauRequestXmlBuilder
{
    private static readonly HashSet<int> SignedReportDetails = new() { 0, 1, 2, 4, 5, 6, 7 };

    public BureauRequestBuildResult Build(
        BureauRequestModel model,
        ParametersBureau parameters,
        DBOrganization organization)
    {
        var request = new XmlRequest
        {
            Version = "11.00",
            Header = MapHeader(organization),
            Body = new()
            {
                RequestAttributes = MapRequestAttributes(model, parameters, organization),
                NaturalPersonSubject = model.NaturalPerson is null ? null : MapNaturalPerson(model.NaturalPerson),
                LegalPersonSubject = model.LegalPerson is null ? null : MapLegalPerson(model.LegalPerson)
            }
        };

        var detail = parameters.CreditReport ? parameters.CreditReportDetalization : 3;
        return new BureauRequestBuildResult(request.Serialize(), SignedReportDetails.Contains(detail));
    }

    public ParametersBureau DeserializeParameters(string xml)
    {
        var parameters = xml.Deserialize<SavedResponseCapabilities>();
        return new ParametersBureau
        {
            PreviousRequests = parameters.PreviousRequestsCountLimit > 0,
            PreviousRequestsCount = parameters.PreviousRequestsCountLimit,
            CreditReport = parameters.CreditReportDetalization != 3,
            CreditReportDetalization = parameters.CreditReportDetalization,
            GetReportWithAMP = IsTrue(parameters.GetReportWithAmp),
            GetBailiffsServiceDebtInfo = IsTrue(parameters.GetBailiffsServiceDebtInfo),
            GetVerificationService = IsTrue(parameters.GetVerificationService),
            GetMIAServiceDocCheck = IsTrue(parameters.GetMIAServiceDocCheck),
            GetMIAServiceRegCheck = IsTrue(parameters.GetMIAServiceRegCheck),
            GetTaxServiceTaxNum = IsTrue(parameters.GetTaxServiceTaxNum),
            GetTaxServiceTaxNumCheck = IsTrue(parameters.GetTaxServiceTaxNumCheck),
            GetPFRServiceSocialNumCheck = IsTrue(parameters.GetPFRServiceSocialNumCheck),
            GetActivityNavigator = IsTrue(parameters.GetActivityNavigator),
            GetReportWithBailiffsDebtInfo = IsTrue(parameters.GetReportWithBailiffsDebtInfo),
            GetSelfEmployedCheck = IsTrue(parameters.GetSelfEmployedCheck),
            Fms = parameters.GetMigrationServiceDocumentCheck is 1 or 2,
            Fns = parameters.GetMigrationServiceDocumentCheck == 2
        };
    }

    private static bool IsTrue(string value) =>
        !string.IsNullOrWhiteSpace(value) && value.Equals("true", StringComparison.OrdinalIgnoreCase);

    private static TRequestHeader MapHeader(DBOrganization organization)
    {
        var userLegalEntity = new TUserLegalEntity
        {
            RegisteredInRf = "1",
            UserName = new TName
            {
                FullName = organization.FullName,
                ShortName = NullIfEmpty(organization.ShortName)
            },
            UserPsrn = new TInfoSrn
            {
                PsrnCode = TpsrnCode.Item1,
                Psrn = organization.Psrn
            }
        };

        userLegalEntity.UserItn.Add(new TInfoItn
        {
            ItnCode = TitnCode.Item1,
            Itn = organization.Itn
        });

        return new()
        {
            RequestDate = DateTime.Now.ToString("dd.MM.yyyy"),
            User = new TUser
            {
                UserId = organization.LegalPersonId.ToString(),
                UserCode = ParseXmlEnum<TUserCode>(organization.OrganizationTypeId.ToString()),
                UserLegalEntity = userLegalEntity
            }
        };
    }

    private static TRequestAttributes MapRequestAttributes(
        BureauRequestModel model,
        ParametersBureau parameters,
        DBOrganization organization)
    {
        var result = new TRequestAttributes()
        {
            ResponseCapabilities = MapResponseCapabilities(model, parameters),
            Consent = model.Consent.Available == "2" ? MapConsent(model, organization) : null,
            Reason = model.Reason.Type == "0" ? null : MapReason(model.Reason)
        };
        result.RequestPurpose.Add(new TReference0
        {
            Type = ParseXmlEnum<TRequestPurpose>(model.RequestPurpose.Type),
            Value = NullIfEmpty(model.RequestPurpose.Value)
        });

        return result;
    }

    private static TResponseCapabilities MapResponseCapabilities(BureauRequestModel model, ParametersBureau parameters)
    {
        var migrationService = !parameters.Fms
            ? TgetMigrationServiceDocumentCheck.Item0
            : !parameters.Fns
                ? TgetMigrationServiceDocumentCheck.Item1
                : TgetMigrationServiceDocumentCheck.Item2;

        return new()
        {
            SelfRequestInResponse = true,
            SelfRequestInResponseSpecified = true,
            CreditReportDetalization = ParseXmlEnum<TReportDetalization>(
                (parameters.CreditReport ? parameters.CreditReportDetalization : 3).ToString()),
            PreviousRequestsCountLimit = parameters.PreviousRequests
                ? parameters.PreviousRequestsCount.ToString()
                : null,
            GetMigrationServiceDocumentCheck = migrationService,
            GetMigrationServiceDocumentCheckSpecified = parameters.Fms,
            GetBailiffsServiceDebtInfo = parameters.GetBailiffsServiceDebtInfo,
            GetBailiffsServiceDebtInfoSpecified = parameters.GetBailiffsServiceDebtInfo,
            GetReportWithAmp = parameters.GetReportWithAMP,
            GetReportWithAmpSpecified = parameters.GetReportWithAMP,
            GetReportWithBailiffsDebtInfo = parameters.GetReportWithBailiffsDebtInfo,
            GetReportWithBailiffsDebtInfoSpecified = parameters.GetReportWithBailiffsDebtInfo,
            GetTaxServiceTaxNum = parameters.GetTaxServiceTaxNum,
            GetTaxServiceTaxNumSpecified = parameters.GetTaxServiceTaxNum,
            GetTaxServiceTaxNumCheck = parameters.GetTaxServiceTaxNumCheck,
            GetTaxServiceTaxNumCheckSpecified = parameters.GetTaxServiceTaxNumCheck,
            GetMiaServiceDocCheck = parameters.GetMIAServiceDocCheck,
            GetMiaServiceDocCheckSpecified = parameters.GetMIAServiceDocCheck,
            GetMiaServiceRegCheck = parameters.GetMIAServiceRegCheck,
            GetMiaServiceRegCheckSpecified = parameters.GetMIAServiceRegCheck,
            GetActivityNavigator = parameters.GetActivityNavigator,
            GetActivityNavigatorSpecified = parameters.GetActivityNavigator,
            GetPfrServiceSocialNumCheck = parameters.GetPFRServiceSocialNumCheck,
            GetPfrServiceSocialNumCheckSpecified = parameters.GetPFRServiceSocialNumCheck,
            GetSelfEmployedCheck = parameters.GetSelfEmployedCheck
                ? new TResponseCapabilitiesGetSelfEmployedCheck
                { 
                    Value = true, 
                    CheckDate = model.ResponseCapabilities.GetSelfEmployedCheck.CheckDate.ToDateTime(TimeOnly.MinValue),
                    CheckDateSpecified = model.ResponseCapabilities.GetSelfEmployedCheck.CheckDate != default
                } 
                : null
        };
    }

    private static TConsent MapConsent(BureauRequestModel model, DBOrganization organization)
    {
        var consent = model.Consent;
        var result = new TConsent
        {
            OtherPurposeAsText = consent.PurposeType == "99" ? NullIfEmpty(consent.OtherPurpose) : null,
            IssueDate = consent.IssueDate,
            ExpiryDate = consent.ExpiryDate,
            ConsentExpiration = ParseXmlEnum<TConsentExpiration>(consent.ExpirationType),
            RequestorResponsibility = consent.RequestorResponsibility,
            NaturalPersonSubject = model.NaturalPerson is null
                ? null
                : MapConsentNaturalPerson(model.NaturalPerson),
            LegalPersonSubject = model.LegalPerson is null
                ? null
                : MapConsentLegalPerson(model.LegalPerson, consent.LegalPersonAddress),
            UserLegalEntity = new TUserLegalEntityForConcent
            {
                FullName = organization.FullName,
                IndividualTaxpayerNumber = organization.Itn,
                PrimaryStateRegistrationNumber = organization.Psrn
            }
        };

        result.Purpose.Add(new TReference0
        {
            Type = ParseXmlEnum<TRequestPurpose>(consent.PurposeType)
        });

        return result;
    }

    private static TNaturalPersonSubjectForConcent MapConsentNaturalPerson(NaturalPersonModel person)
    {
        var result = new TNaturalPersonSubjectForConcent
        {
            BirthDate = person.BirthDate
        };

        result.Name.Add(new TNaturalPersonName
        {
            LastName = person.LastName.Trim(),
            FirstName = person.FirstName.Trim(),
            MiddleName = NullIfEmpty(person.MiddleName)
        });
        result.IdentificationDocument.Add(MapDocument(person.Document));

        return result;
    }

    private static TLegalPersonSubjectForConcent MapConsentLegalPerson(LegalPersonModel person, string address)
    {
        return new TLegalPersonSubjectForConcent
        {
            Address = address,
            IndividualTaxpayerNumber = person.IndividualTaxpayerNumber.Trim(),
            PrimaryStateRegistrationNumber = person.PrimaryStateRegistrationNumber.Trim(),
            Name = new TLegalNameForConcent
            {
                FullName = person.FullName.Trim()
            }
        };
    }

    private static TNaturalPersonSubject MapNaturalPerson(NaturalPersonModel person)
    {
        var result = new TNaturalPersonSubject
        {
            BirthDate = person.BirthDate,
            CitizenshipCountryCode = "643",
            Gender = ParseXmlEnum<TGender>(person.Gender),
            GenderSpecified = person.Gender != "0",
            PensionNumber = DigitsOnly(person.PensionNumber),
            IndividualTaxpayerNumber = NullIfEmpty(person.IndividualTaxpayerNumber),
            InnChecked = person.InnChecked,
            InnCheckedSpecified = !string.IsNullOrWhiteSpace(person.IndividualTaxpayerNumber)
        };

        result.Title.Add(new TNaturalPersonTitle
        {
            LastName = person.LastName.Trim(),
            FirstName = person.FirstName.Trim(),
            MiddleName = NullIfEmpty(person.MiddleName)
        });
        result.IdentificationDocument.Add(MapDocument(person.Document));

        foreach (var address in person.Addresses)
        {
            result.Address.Add(MapAddress(address));
        }

        foreach (var phone in person.Phones)
        {
            result.Phone.Add(MapNaturalPersonPhone(phone));
        }

        return result;
    }

    private static TLegalPerson MapLegalPerson(LegalPersonModel person)
    {
        var result = new TLegalPerson
        {
            CountryCode = "643",
            Title = new TLegalTitle
            {
                IndividualTaxpayerNumber = person.IndividualTaxpayerNumber.Trim(),
                PrimaryStateRegistrationNumber = person.PrimaryStateRegistrationNumber.Trim(),
                Name = new TLegalName
                {
                    FullName = person.FullName.Trim()
                }
            }
        };

        foreach (var address in person.Addresses)
        {
            result.Address.Add(MapAddress(address));
        }

        foreach (var phone in person.Phones)
        {
            result.Phone.Add(MapPhone(phone));
        }

        return result;
    }

    private static TNaturalPersonIdentificationDocument MapDocument(IdentificationDocumentModel document)
    {
        return new TNaturalPersonIdentificationDocument
        {
            DocTypeId = ParseXmlEnum<TDocCode>(document.Type),
            DocSer = NullIfEmpty(document.Series),
            DocNum = document.Number.Trim(),
            DocDate = document.IssueDate,
            DocDelivInstCode = NullIfEmpty(document.IssuerCode),
            DocDelivInstName = NullIfEmpty(document.IssuerName)
        };
    }

    private static TAddressWithUseExtension MapAddress(AddressModel address)
    {
        var result = new TAddressWithUseExtension();

        result.Caption.Add(new TCaption
        {
            Id = ParseXmlEnum<TAddressKind>(address.Type)
        });

        if (DateTime.TryParse(address.RegistrationDate, out var registrationDate))
        {
            result.RegistrationDate = registrationDate;
            result.RegistrationDateSpecified = true;
        }

        if (address.RegionId != "0")
        {
            result.Region = new TRegion
            {
                Id = ParseXmlEnum<TRegionId>(address.RegionId),
                Text = address.RegionName
            };
        }

        if (!string.IsNullOrEmpty(address.DistrictType))
        {
            result.District = new TDistrict
            {
                Ext = ParseXmlEnum<TDistrictExt>(address.DistrictType),
                Caption = address.DistrictName
            };
        }

        if (!string.IsNullOrEmpty(address.CityType))
        {
            result.City = new TCity
            {
                Ext = ParseXmlEnum<TCityExt>(address.CityType),
                Caption = address.CityName
            };
        }

        if (!string.IsNullOrEmpty(address.VillageType))
        {
            result.Village = new TVillage
            {
                Ext = ParseXmlEnum<TVillageExt>(address.VillageType),
                Caption = address.VillageName
            };
        }

        if (!string.IsNullOrEmpty(address.StreetType) ||
            !string.IsNullOrEmpty(address.HouseNumber) ||
            !string.IsNullOrEmpty(address.BuildingNumber) ||
            !string.IsNullOrEmpty(address.BuildingSymbol) ||
            !string.IsNullOrEmpty(address.FlatNumber))
        {
            result.StreetAddress = new TStreetAddress
            {
                HouseNum = NullIfEmpty(address.HouseNumber),
                BuildingNum = NullIfEmpty(address.BuildingNumber),
                BuildingSymbol = NullIfEmpty(address.BuildingSymbol),
                FlatNum = NullIfEmpty(address.FlatNumber),
                Street = string.IsNullOrEmpty(address.StreetType)
                    ? null
                    : new TStreet
                    {
                        Ext = ParseXmlEnum<TStreetExt>(address.StreetType),
                        Caption = address.StreetName
                    }
            };
        }

        return result;
    }

    private static TPhoneWithConfirmationExtension MapNaturalPersonPhone(PhoneModel phone)
    {
        return new TPhoneWithConfirmationExtension
        {
            Id = ParseXmlEnum<TPhoneKind>(phone.Type),
            Number = NullIfEmpty(phone.Number)
        };
    }

    private static TPhone MapPhone(PhoneModel phone)
    {
        return new TPhone
        {
            Id = ParseXmlEnum<TPhoneKind>(phone.Type),
            Number = NullIfEmpty(phone.Number)
        };
    }

    private static TRequestAttributesReason MapReason(BureauReasonModel reason)
    {
        var result = new TRequestAttributesReason
        {
            Id = ParseXmlEnum<TCreditTypeCode>(reason.Type),
            CurrencyCaption = NullIfEmpty(reason.Currency),
            ApplicationType = new TRequestAttributesReasonApplicationType
            {
                Type = ParseXmlEnum<TApplication>(reason.ApplicationType),
                Value = reason.ApplicationTypeText
            },
            ApplicationOrigin = new TRequestAttributesReasonApplicationOrigin
            {
                Type = ParseXmlEnum<TApplicationOrigin>(reason.ApplicationOrigin),
                Value = reason.ApplicationOriginText
            }
        };

        if (!string.IsNullOrWhiteSpace(reason.CreditLimit))
        {
            if (!decimal.TryParse(reason.CreditLimit, NumberStyles.Number, CultureInfo.CurrentCulture, out var creditLimit) &&
                !decimal.TryParse(reason.CreditLimit, NumberStyles.Number, CultureInfo.InvariantCulture, out creditLimit))
            {
                throw new FormatException($"Некорректная сумма заявки: {reason.CreditLimit}");
            }

            result.CustomerClaimCreditLimit = creditLimit;
            result.CustomerClaimCreditLimitSpecified = true;
        }

        return result;
    }

    private static TEnum ParseXmlEnum<TEnum>(string value)
        where TEnum : struct, Enum
    {
        foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var xmlName = field.GetCustomAttribute<XmlEnumAttribute>()?.Name ?? field.Name;
            if (xmlName == value)
            {
                return (TEnum)field.GetValue(null)!;
            }
        }

        throw new ArgumentOutOfRangeException(
            nameof(value),
            value,
            $"Значение не поддерживается схемой {typeof(TEnum).Name}");
    }

    private static string? NullIfEmpty(string? value) =>
        string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    
    private static string? DigitsOnly(string input) => 
        string.IsNullOrWhiteSpace(input)
            ? null 
            : string.Concat(input.Where(char.IsDigit));
}
