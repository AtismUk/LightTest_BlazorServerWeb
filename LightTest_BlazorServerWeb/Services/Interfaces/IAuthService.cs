using LightTest_BlazorServerWeb.Models;
using LightTest_BlazorServerWeb.Models.AuthModel;

namespace LightTest_BlazorServerWeb.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseService<bool>> AuthUserAsync(LoginModel loginModel);
        Task<ResponseService<UserSession>> GetUserInfoAsync();
        Task LogoutAsync();

    }
}
