namespace LightTest_BlazorServerWeb.DataBase.Models.MainPart
{
    public class StoreEntity
    {
        public string Guid { get; set; }
        public bool isDocument { get; set; } = false;
        public bool isVideo { get; set; } = false;
        public bool isPhoto { get; set; } = false;

        public int? TopicId { get; set; }
        public int ArticleId { get; set; }
        public TopicEntity Topic { get; set; }
        public ArticleEntity Article { get; set; }
    }
}
