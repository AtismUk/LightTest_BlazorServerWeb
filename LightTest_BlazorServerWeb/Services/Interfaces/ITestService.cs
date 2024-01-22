using LightTest_BlazorServerWeb.Models;
using LightTest_BlazorServerWeb.Models.Output.Test;

namespace LightTest_BlazorServerWeb.Services.Interfaces
{
    public interface ITestService
    {
        Task<ResponseService<ResultOfTest>> ConfirmTestAsync(TestModel testModel);
    }
}
