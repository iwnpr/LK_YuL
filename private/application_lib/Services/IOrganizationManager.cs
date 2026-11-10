
using application_lib.Entities;
using legal_persons_lib.Entities;
using legal_persons_lib.Services;

namespace application_services_lib.Services
{
    public interface IOrganizationManager
    {
        /// <summary>
        /// Получение параметров организации по id
        /// </summary>
        /// <param name="id">Идентификатор организации</param>
        /// <returns></returns>
        Task<DBOrganization?> GetAsync(int id);

        /// <summary>
        /// Плучение параметров всех организаций
        /// </summary>
        /// <returns></returns>
        Task<List<DBOrganization>> GetListAsync();

        /// <summary>
        /// Получение списка типов организаций
        /// </summary>
        /// <returns></returns>
        Task<List<DBOrganizationType>> GetTypesAsync();

        /// <summary>
        /// Получение правд доступа к сервисам по id
        /// </summary>
        /// <param name="id">Идентификатор организации</param>
        /// <returns></returns>
        Task<List<DBOrganizationAccess>> GetAccessesAsync(int id);

        /// <summary>
        /// Обновление параметров организации
        /// </summary>
        /// <param name="_org">Параметры организации</param>
        /// <returns>Результат операции</returns>
        Task<Answer> UpdateAsync(DBOrganization _org, List<DBOrganizationAccess> _rights);

        /// <summary>
        /// Добавление новой организации
        /// </summary>
        /// <param name="_org">Параметры организации</param>
        /// <returns>Результат операции</returns>
        Task<Answer> InsertAsync(DBOrganization _org, List<DBOrganizationAccess> _rights);
    }

    public class OrganizationManager : IOrganizationManager
    {
        private readonly IRepository<DBOrganization> _organizations;
        private readonly IRepository<DBOrganizationType> _types;
        private readonly IRepository<DBOrganizationAccess> _accesses;

        /// <summary>
        /// Конструктор для внедрения
        /// </summary>
        /// <param name="organizations"></param>
        /// <param name="types"></param>
        /// <param name="accesses"></param>
        public OrganizationManager(IRepository<DBOrganization> organizations, IRepository<DBOrganizationType> types, IRepository<DBOrganizationAccess> accesses)
        {
            _organizations = organizations;
            _types = types;
            _accesses = accesses;
        }

        /// <inheritdoc/>>       
        public async Task<DBOrganization?> GetAsync(int id) => await _organizations.GetAsync(id);

        /// <inheritdoc/>>
        public async Task<List<DBOrganizationAccess>> GetAccessesAsync(int id) => await _accesses.GetListAsync(a => a.OrganizationId.Equals(id));

        /// <inheritdoc/>>
        public async Task<List<DBOrganization>> GetListAsync() => await _organizations.GetListAsync();

        /// <inheritdoc/>>
        public async Task<List<DBOrganizationType>> GetTypesAsync() => await _types.GetListAsync();

        /// <inheritdoc/>>
        public async Task<Answer> InsertAsync(DBOrganization _org, List<DBOrganizationAccess> _rights)
        {
            //Организация с таким Id уже существует
            if (await _organizations.GetSingleAsync(o => o.LegalPersonId.Equals(_org.LegalPersonId)) is not null)
                return new Answer(-1, "Организация с таким Id уже существует!");

            //Организация с таким ИНН уже существует
            if (await _organizations.GetSingleAsync(o => o.Itn.Equals(_org.Itn)) is not null)
                return new Answer(-1, "Организация с таким ИНН уже существует!");

            if (!await _organizations.InsertAsync(_org))
            {
                return new Answer(-1, "Ошибка при добавлении организации!");
            }

            return !await UpdateAccessesAsync(_org.Id, _rights) ? new Answer(200, "Организация добавлена!") : new Answer(-1, "Не удалось обновить некоторые права доступа!");
        }

        /// <inheritdoc/>>
        public async Task<Answer> UpdateAsync(DBOrganization _org, List<DBOrganizationAccess> _rights)
        {
            DBOrganization? org = await _organizations.GetAsync(_org.Id);

            if (org is null)
                return new Answer(-1, "Организация с таким id не существует");

            //Если меняется id организации, то он должен быть уникальным
            if (!org.LegalPersonId.Equals(_org.LegalPersonId) && await _organizations.GetSingleAsync(o => o.LegalPersonId.Equals(_org.LegalPersonId)) is not null)
                return new Answer(-1, "Организация с таким id уже существует");

            //Если изменяется ИНН, то он должен быть уникальным
            if (!org.Itn.Equals(_org.Itn) && await _organizations.GetSingleAsync(o => o.Itn.Equals(_org.Itn)) is not null)
               return new Answer(-1, "Организация с таким ИНН уже существует");

            //Изменение данных
            if (!await _organizations.UpdateAsync(_org))
                return new Answer(-1, "При обновлении параметров организации произошла ошибка!");

            return !await UpdateAccessesAsync(_org.Id, _rights) ? new Answer(200, "Параметры организации обновлены!") : new Answer(-1, "Не удалось обновить некоторые права доступа!");
        }

        /// <summary>
        /// Обноление прав доступа организации
        /// </summary>
        /// <param name="_id">Идентификатор организации</param>
        /// <param name="_rights">Список прав доступа</param>
        /// <returns></returns>
        private async Task<bool> UpdateAccessesAsync(int _id, List<DBOrganizationAccess> _rights)
        {
            _rights.ForEach(service => service.OrganizationId = _id);

            DBOrganizationAccess? service = new DBOrganizationAccess();

            bool _error = false;

            foreach (var access in _rights)
            {
                service = await _accesses.GetSingleAsync(a => a.ServiceId.Equals(access.ServiceId) && a.OrganizationId.Equals(_id));

                if (service is null)
                {
                    if (access.Access)
                        if (!await _accesses.InsertAsync(access))
                            _error = true;
                }
                else
                {
                    service.Access = access.Access;
                    if (!await _accesses.UpdateAsync(service))
                        _error = true;
                }
            }

            return _error;
        }
    }
}
