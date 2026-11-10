using legal_persons_lib.Entities;
using legal_persons_lib.Services;

namespace application_lib.Services
{
    public interface IServiceManager
    {
        Task<DBService?> GetAsync(int id);
        Task<List<DBService>> GetListAsync();
    }

    public class ServiceManager : IServiceManager
    {
        private readonly IRepository<DBService> _services;

        public ServiceManager(IRepository<DBService> services)
        {
            _services = services;
        }
        public async Task<DBService?> GetAsync(int id) => await _services.GetAsync(id);

        public async Task<List<DBService>> GetListAsync() => await _services.GetListAsync();
    }
}
