using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LightTest_BlazorServerWeb.Models.Output.Test
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Text { get; set; }
        public bool isSeveral { get; set; } = false;
        public int selected { get; set; } = 0;
        public List<AnswerModel> Answers { get; set; } = new();
    }
}
