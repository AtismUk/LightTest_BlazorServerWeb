using LightTest_BlazorServerWeb.DataBase.Models.MainPart;

namespace LightTest_BlazorServerWeb.DataBase.Models.Test
{
    public class TestEntity : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CountOfCorrectQuestions { get; set; }
        public int? TopicId { get; set; }
        public TopicEntity? Topic { get; set; }
        public List<QuestionEntity> Questions { get; set; }
    }
}
