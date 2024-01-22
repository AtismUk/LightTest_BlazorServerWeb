namespace LightTest_BlazorServerWeb.Models.Output.Test
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool isSelected { get; set; } = false;
        public List<QuestionModel> Questions { get; set; }
    }
}
