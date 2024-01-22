using LightTest_BlazorServerWeb.DataBase.Models.Test;

namespace LightTest_BlazorServerWeb.Models.Output.Test
{
    public class TestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<QuestionModel> Questions { get; set; } = new();
    }
}
