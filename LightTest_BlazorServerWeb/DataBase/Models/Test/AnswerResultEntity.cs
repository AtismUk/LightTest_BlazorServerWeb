namespace LightTest_BlazorServerWeb.DataBase.Models.Test
{
    public class AnswerResultEntity : BaseModel
    {
        public int TestResultId { get; set; }
        public TestResultEntity TestResult { get; set; }
        public int answerId { get; set; }
        public int questionId { get; set; }
        public AnswerEntity Answer { get; set; }
        public QuestionEntity Question { get; set; }
    }
}
