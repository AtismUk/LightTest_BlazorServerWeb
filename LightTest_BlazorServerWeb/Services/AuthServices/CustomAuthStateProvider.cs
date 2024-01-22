using LightTest_BlazorServerWeb.Models;
using LightTest_BlazorServerWeb.Models.AuthModel;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace LightTest_BlazorServerWeb.Services.AuthServices
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _session;
        private ClaimsPrincipal _anonym = new ClaimsPrincipal(new ClaimsIdentity());
        public CustomAuthStateProvider(ProtectedSessionStorage session)
        {
            _session = session;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var state = new AuthenticationState(_anonym);
            try
            {
                var userSession = await GetUserSessionAsync();

                if (!userSession.isValid)
                {
                    return state;
                }

                var claims = CreateClaims(userSession.Value!);

                var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "customAuth"));
                state = new AuthenticationState(claimPrincipal);
                return await Task.FromResult(state);

            }
            catch (Exception)
            {
                return await Task.FromResult(state);
            }
        }


        public async Task AuthUserAsync(UserSession userSession = null)
        {
            ClaimsPrincipal claimsPrincipal;
            if (userSession == null)
            {
                await _session.SetAsync("UserSession", userSession!);
                var claims = CreateClaims(userSession!);

                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "CustomAuth"));

            }
            else
            {
                await _session.DeleteAsync("UserSession");
                claimsPrincipal = _anonym;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }


        public async Task<ResponseService<UserSession>> GetUserSessionAsync()
        {
            var protectedSession = await _session.GetAsync<UserSession>("UserSession");
            var userSession = protectedSession.Success ? protectedSession.Value : null;

            if (userSession == null)
            {
                return new();
            }
            return new()
            {
                isValid = true,
                Value = userSession
            };
        }


        private List<Claim> CreateClaims(UserSession userSession)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, userSession.Login),
                new Claim(ClaimTypes.Name, userSession.Name)
            };

            if (userSession.isAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            else
            {
                foreach (var groupId in userSession.groupsId)
                {
                    claims.Add(new Claim(ClaimTypes.GroupSid, groupId.ToString()));
                }
            }
            return claims;
        }
    }
}
