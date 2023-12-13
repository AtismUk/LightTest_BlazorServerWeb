namespace LightTest_BlazorServerWeb.DataBase.Models.MainPart
{
    public class Article : BaseModel
    {
        public string Title { get; set; }
        public string Desctiption { get; set; }
        public string? Text { get; set; }
        public int topicId { get; set; }
        public Topic Topic { get; set; }

        public List<Article> Articles { get; set; }
    }
}
