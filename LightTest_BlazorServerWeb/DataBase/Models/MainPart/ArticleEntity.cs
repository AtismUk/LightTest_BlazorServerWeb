namespace LightTest_BlazorServerWeb.DataBase.Models.MainPart
{
    public class ArticleEntity : BaseModel
    {
        public string Title { get; set; }
        public string Desctiption { get; set; }
        public string? Text { get; set; }
        public int topicId { get; set; }
        public TopicEntity Topic { get; set; }

        public List<ArticleEntity> Articles { get; set; }
    }
}
