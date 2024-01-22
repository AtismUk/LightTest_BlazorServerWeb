
using LightTest_BlazorServerWeb.DataBase;
using LightTest_BlazorServerWeb.DataBase.Models.UserPart;
using LightTest_BlazorServerWeb.Models;
using LightTest_BlazorServerWeb.Models.AuthModel;
using LightTest_BlazorServerWeb.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

namespace LightTest_BlazorServerWeb.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly CustomAuthStateProvider _customAuthState;
        public AuthService(AppDbContext appDbContext, AuthenticationStateProvider authenticationStateProvider)
        {
            _context = appDbContext;
            _customAuthState = (CustomAuthStateProvider)authenticationStateProvider;
        }

        public async Task<ResponseService<bool>> AuthUserAsync(LoginModel loginModel)
        {
            var user = await _context.Users.Include(x => x.Groups).FirstOrDefaultAsync(x => x.Login == loginModel.Login && x.Password == loginModel.Password);
            if (user != null)
            {
                UserSession userSession = new()
                {
                    Name = user.Name,
                    Login = user.Login,
                    isAdmin = user.isAdmin
                };
                foreach (var group in user.Groups)
                {
                    userSession.groupsId.Add(group.Id);
                }

                await _customAuthState.AuthUserAsync(userSession);

                return new()
                {
                    isValid = true
                };
            }

            return new()
            {
                Message = "Неверный логин или пароль"
            };
        }

        public async Task LogoutAsync()
        {
            await _customAuthState.AuthUserAsync();
        }

        public async Task<ResponseService<UserSession>> GetUserInfoAsync()
        {
            return await _customAuthState.GetUserSessionAsync();
        }

    }
}
