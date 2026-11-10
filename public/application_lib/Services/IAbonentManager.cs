
using application_lib.Entities;
using legal_persons_lib.Entities;
using legal_persons_lib.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using qbch_lib;
using qbch_lib.Entities;
using Serilog;
using System.Linq;

namespace application_lib.Services
{
    public interface IAbonentManager
    {
        /// <summary>
        /// Получение параметров абонента по id
        /// </summary>
        /// <param name="id">Идентификатор абонента</param>
        /// <returns></returns>
        Task<DBAbonent?> GetAsync(int id);

        /// <summary>
        /// Плучение списка абонентов
        /// </summary>
        /// <returns></returns>
        Task<List<DBAbonent>> GetListAsync();

        /// <summary>
        /// Полечение списка отпечатков сертификатов абонентов
        /// </summary>
        /// <param name="id">Идентификатор абонента</param>
        /// <returns>Список сертификатов абонента</returns>
        Task<List<DBAbonentCertificate>> GetCertificatesAsync(int id);

        Task<List<DBUserType>> GetUserTypesAsync();

        Task<List<DBMethod>> GetMethodsAsync();

        Task<List<DBPermission>> GetPermissionsAsync(int id);

        Task<Answer> InsertAbonentAsync(DBAbonent abonent, List<DBPermission> permissions);

        Task<Answer> UpdateAbonentAsync(DBAbonent abonent, List<DBPermission> permissions);
        
        Task<Answer> InsertThumbprintAsync(DBAbonentCertificate thumbprint);
        
        Task<Answer> UpdateThumbprintAsync(DBAbonentCertificate thumbprint);


    }

    public class AbonentManager : IAbonentManager
    {
        private readonly IDbContextFactory<BureauQBCHContext> _dbFactory;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="organizations"></param>
        /// <param name="types"></param>
        /// <param name="accesses"></param>
        public AbonentManager(IDbContextFactory<BureauQBCHContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        /// <inheritdoc/>>       
        public async Task<DBAbonent?> GetAsync(int id)
        {
            try
            {
                await using var db = await _dbFactory.CreateDbContextAsync();

                return await db.Abonents.FirstOrDefaultAsync(item => item.KeyId.Equals(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка поиска абонента: {ex.Message}");
                return null;
            }
        }

        public async Task<List<DBAbonentCertificate>> GetCertificatesAsync(int id)
        {
            try
            {
                await using var db = await _dbFactory.CreateDbContextAsync();

                return await db.Certificates.Where(item => item.AbonentKeyId.Equals(id)).ToListAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка получения списка сертификатов абонентов: {ex.Message}");
                return new();
            }
        }

        /// <inheritdoc/>>
        public async Task<List<DBAbonent>> GetListAsync()
        {
            try
            {
                await using var db = await _dbFactory.CreateDbContextAsync();

                return await db.Abonents.ToListAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка получения списка абонентов: {ex.Message}");
                return new();
            }
        }

        /// <inheritdoc/>>
        public async Task<List<DBMethod>> GetMethodsAsync()
        {
            try
            {
                await using var db = await _dbFactory.CreateDbContextAsync();

                return await db.Methods.ToListAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка получения списка методов КБКИ: {ex.Message}");
                return new();
            }
        }

        public async Task<List<DBPermission>> GetPermissionsAsync(int id)
        {
            try
            {
                await using var db = await _dbFactory.CreateDbContextAsync();

                return await db.Permissions.Where(item => item.AbonentsKeyId.Equals(id)).ToListAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка получения прав доступа пользователей: {ex.Message}");
                return new();
            }
        }

        /// <inheritdoc/>>
        public async Task<List<DBUserType>> GetUserTypesAsync()
        {
            try
            {
                await using var db = await _dbFactory.CreateDbContextAsync();

                return await db.UserTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка получения списка типов пользователей: {ex.Message}");
                return new();
            }
        }

        public async Task<Answer> InsertThumbprintAsync(DBAbonentCertificate thumbprint)
        {
            try
            {
                await using var db = await _dbFactory.CreateDbContextAsync();

                await db.Certificates.AddAsync(thumbprint);

                if (await db.SaveChangesAsync() > 0)
                    return new(200, "Сертификат абонента успешно добавлен");
                
                return new(500, "При добавлении сертификата абонента произошла ошибка");
            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка добавления сертификата абонента: {ex.Message}");
                return new (500, "При добавлении сертификата абонента произошла ошибка");
            }
        }

        public async Task<Answer> UpdateThumbprintAsync(DBAbonentCertificate thumbprint)
        {
            try
            {
                await using var db = await _dbFactory.CreateDbContextAsync();

                db.Entry(thumbprint).State = EntityState.Modified;

                if (await db.SaveChangesAsync() > 0)
                    return new(200, "Сертификат абонента успешно добавлен");

                return new(500, "При добавлении сертификата абонента произошла ошибка");
            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка добавления сертификата абонента: {ex.Message}");
                return new(500, "При добавлении сертификата абонента произошла ошибка");
            }
        }

        public async Task<Answer> InsertAbonentAsync(DBAbonent abonent, List<DBPermission> permissions)
        {
            try
            {
                await using var db = await _dbFactory.CreateDbContextAsync();

                await db.Abonents.AddAsync(abonent);

                if (!(await db.SaveChangesAsync() > 0))
                    return new(500, "При добавлении абонента произошла ошибка");

                permissions.ForEach(item => item.AbonentsKeyId = abonent.KeyId);
                await db.Permissions.AddRangeAsync(permissions);

                if (!(await db.SaveChangesAsync() > 0))
                    return new(300, $"Новый абонент {abonent.ShortName} успешно добавлен, но при установке прав доступа произошла ошибка");

                return new(200, $"Новый абонент {abonent.ShortName} успешно добавлен");
            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка добавления сертификата абонента: {ex.Message}");
                return new(500, "При добавлении абонента произошла ошибка");
            }
        }

        public async Task<Answer> UpdateAbonentAsync(DBAbonent abonent, List<DBPermission> permissions)
        {
            try
            {
                await using var db = await _dbFactory.CreateDbContextAsync();

                db.Entry(abonent).State = EntityState.Modified;

                List<DBPermission> _accesses = permissions.Where(_item => _item.KeyId.Equals(0)).ToList();

                await db.Permissions.AddRangeAsync(_accesses);

                permissions.Where(item => !item.KeyId.Equals(0)).ForEach(_item => { db.Entry(_item).State = EntityState.Modified; });

                if (!(await db.SaveChangesAsync() > 0))
                    return new(500, $"При обновлении абонента {abonent.ShortName} произошла ошибка");

                return new(200, $"Данные абонента {abonent.ShortName} успешно обновлены");

            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка добавления сертификата абонента: {ex.Message}");
                return new(500, "При добавлении абонента произошла ошибка");
            }
        }
    }
}
