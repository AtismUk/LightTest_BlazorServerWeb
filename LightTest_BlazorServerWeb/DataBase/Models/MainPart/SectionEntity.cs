namespace LightTest_BlazorServerWeb.DataBase.Models.MainPart
{
    public class SectionEntity : BaseModel
    {
        public string Name { get; set; }
        public int? Section_Id { get; set; }
        public List<ArticleEntity> Articles { get; set; }
    }
}
