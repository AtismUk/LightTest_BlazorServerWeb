namespace LightTest_BlazorServerWeb.DataBase.Models.Test
{
    public class AnswerEntity : BaseModel
    {
        public string Text { get; set; }
        public bool isCorrect { get; set; }

        public int questionId { get; set; }
        public QuestionEntity Question { get; set; }
    }
}
