namespace LightTest_BlazorServerWeb.DataBase.Models.Test
{
    public class QuestionEntity : BaseModel
    {
        public string Name { get; set; }
        public string? Text { get; set; }
        public int testId { get; set; }
        public TestEntity Test { get; set; }
        public List<AnswerEntity> Answers { get; set; }
    }
}
