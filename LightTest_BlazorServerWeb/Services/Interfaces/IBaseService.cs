using LightTest_BlazorServerWeb.DataBase.Models;
using LightTest_BlazorServerWeb.Models;
using LightTest_BlazorServerWeb.Models.Output.Test;

namespace LightTest_BlazorServerWeb.Services.Interfaces
{
    public interface IBaseService
    {
        Task<ResponseService<TestModel>> GetTestByIdAsync(int id);
        Task<ResponseService<int>> SaveEntityAsync<Entity>(Entity entity) where Entity : BaseModel;
        Task<ResponseService<bool>> SaveEntitysAsync<Entity>(List<Entity> entitys, bool isUpdate = false) where Entity : BaseModel;
    }
}
