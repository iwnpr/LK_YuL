using legal_persons_lib.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace legal_persons_lib.Services
{
    public interface IRepository<T> where T : DBEntity
    {
        /// <summary>
        /// Получение всей коллекции сущностей 
        /// </summary>
        /// <returns>Коллекция всех сущностей</returns>
        Task<List<T>> GetListAsync();
        
        /// <summary>
        /// Поиск сущности по идентификатору
        /// </summary>
        /// <param name="_id">Идентификатор сущности</param>
        /// <returns></returns>
        Task<T?> GetAsync(int _id, string? _property = null);

        /// <summary>
        /// Добавление новой сущности
        /// </summary>
        /// <param name="_entity">Сущность</param>
        /// <returns>Результат вставки</returns>
        Task<bool> InsertAsync(T _entity);

        /// <summary>
        /// Поиск сущности по условию (предикату)
        /// </summary>
        /// <param name="predicate">Условие поиска (предикат)</param>
        /// <returns>Сущность</returns>
        Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate, string? _property = null);

        /// <summary>
        /// Поиск коллекции сущностей по условию (предикату)
        /// </summary>
        /// <param name="predicate">Условие поиска (предикат)</param>
        /// <returns>Коллекция данных, удовлетворяющих условию поиска</returns>
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Обновление сущности
        /// </summary>
        /// <param name="_entity">Сущность для обновления</param>
        /// <returns>Результат обновления</returns>
        Task<bool> UpdateAsync(T _entity);
    }

    public class Repository<T> : IRepository<T> where T : DBEntity
    {
        private readonly IDbContextFactory<LegalPersonsContext> _contextFactory;
        private readonly ILogger<Repository<T>> _logger;


        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="contextFactory">Фабрика контекстов базы данных</param>
        /// <param name="logger">Логгер</param>
        public Repository(IDbContextFactory<LegalPersonsContext> contextFactory, ILogger<Repository<T>> logger) => (_contextFactory, _logger) = (contextFactory, logger);
        

        /// <inheritdoc/>>
        private async Task<bool> ApplyAsync(LegalPersonsContext context)
        {
            try 
            { 
                if (await context.SaveChangesAsync() <= 0)
                    return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка сохранения изменений сущности {EntityType}", typeof(T).Name);
                return false; 
            }
            
            return true;
        }
        
        /// <inheritdoc/>>
        public async Task<bool> UpdateAsync(T _entity)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            context.Entry(_entity).State = EntityState.Modified;

            return await ApplyAsync(context);
        }
        
        /// <inheritdoc/>>
        public async Task<T?> GetAsync(int _id, string? _property = null)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            var query = context.Set<T>().Where(e => e.Id.Equals(_id));
            if (_property is not null)
                query = query.Include(_property);

            return await query.FirstOrDefaultAsync();
        }

        /// <inheritdoc/>>
        public async Task<List<T>> GetListAsync()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            return await context.Set<T>().OrderByDescending(t => t.Id).ToListAsync();
        }

        /// <inheritdoc/>>
        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            return await context.Set<T>().Where(predicate).OrderByDescending(t => t.Id).ToListAsync();
        }

        /// <inheritdoc/>>
        public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate, string? _property)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            IQueryable<T> query = context.Set<T>();
            if (_property is not null)
                query = query.Include(_property);

            return await query.FirstOrDefaultAsync(predicate);
        }

        /// <inheritdoc/>>
        public async Task<bool> InsertAsync(T _entity)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            await context.Set<T>().AddAsync(_entity);
            return await ApplyAsync(context);
        }

    }
}
