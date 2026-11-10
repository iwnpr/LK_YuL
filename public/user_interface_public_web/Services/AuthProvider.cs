using application_lib.Services;
using legal_persons_lib.Entities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;
using System.Text.Json;

namespace user_interface_web.Services
{
    public class AuthProvider: AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _session;
        private readonly IUserManager _userMngr;
        private readonly IOrganizationManager _orgMngr;

        public AuthProvider(ProtectedSessionStorage session, IUserManager userMngr, IOrganizationManager orgMngr, ILogger<AuthProvider> logger)
        {
            _session = session;
            _userMngr = userMngr;
            _orgMngr = orgMngr;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            AuthenticationState _anonymous = new(new ClaimsPrincipal(new ClaimsIdentity()));

            DBUser? _user;

            ProtectedBrowserStorageResult<string> _userJson;

            try
            {
               _userJson = await _session.GetAsync<string>("User");
            }
            catch
            {
                return _anonymous;
            }

            if (!_userJson.Success)
            {
                return _anonymous;
            }

            try
            { 
                _user = JsonSerializer.Deserialize<DBUser>(_userJson.Value!);
            }
            catch 
            {
                return _anonymous;
            }

            if (_user is null)
            {
                return _anonymous;
            }

            var claims = new List<Claim>
            {
                new ("Caption", $"{_user.LastName} {_user.FirstName}{(_user.MiddleName == null ? string.Empty : " " + _user.MiddleName)}"),
                new ("User", JsonSerializer.Serialize(_user)),
            };

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
