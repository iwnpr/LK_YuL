using application_lib.Services;
using application_services_lib.Services;
using legal_persons_lib.Entities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;
using System.Text.Json;
using user_interface_private_web.Entities;

namespace user_interface_private_web.Services
{
    public class AuthProvider: AuthenticationStateProvider
    {
        private ILogger<AuthProvider> _logger;
        private readonly ProtectedSessionStorage _session;
        private readonly IUserManager _userMngr;
        private readonly IOrganizationManager _orgMngr;

        public AuthProvider(ProtectedSessionStorage session, IUserManager userMngr, IOrganizationManager orgMngr, ILogger<AuthProvider> logger)
        {
            _session = session;
            _userMngr = userMngr;
            _orgMngr = orgMngr;
            _logger = logger;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            AuthenticationState _anonymous = new(new ClaimsPrincipal(new ClaimsIdentity()));

            ProtectedBrowserStorageResult<string> _connection = await _session.GetAsync<string>("Connection");

            if (!_connection.Success)
            {
                return _anonymous;
            }

            DBUser? _user = await _userMngr.GetUserAsync(JsonSerializer.Deserialize<ConnectionParameters>(_connection.Value).SerialNumber);

            if (_user is null)
            {
                _logger.LogWarning($"Ошибка входа в личный кабинет");
                return _anonymous;
            }

            await _session.SetAsync("UserDB", _user!);

            if (!_user.Organization.IsActive)
            {
                _logger.LogWarning($"Организация пользователя {_user.Organization.ShortName} заблокирована");
                return _anonymous;
            }

            if (!_user.IsActive)
            {
                _logger.LogWarning($"Пользователь {_user.LastName} {_user.FirstName} заблокирован");
                return _anonymous;
            }

            var claims = new List<Claim>
            {
                new Claim("Caption", $"{_user.LastName} {_user.FirstName}{(_user.MiddleName == null ? string.Empty : " " + _user.MiddleName)}"),
                new Claim("User", JsonSerializer.Serialize(_user)),
            };

            //TODO объединить с правами организации
            var _accesses = await _userMngr.GetAccessesAsync(_user.Id);

            _accesses =
                (await _orgMngr.GetAccessesAsync(_user.OrganizationId))
                .Where(a => a.Access)
                .Select(a => new DBUserAccess() { Id = a.Id, Access = (_accesses.FirstOrDefault(u => u.ServiceId.Equals(a.ServiceId))?.Access ?? false), Comment = a.Comment, ServiceName = a.ServiceName, ServiceId = a.ServiceId })
                .ToList();

            foreach (var _access in _accesses.Where(a => a.Access)) 
            {
                claims.Add(new Claim(ClaimTypes.Role, _access.ServiceName));
            }

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "AuthType")));
        }

        public void UpdateAsync()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
        
    }
}
