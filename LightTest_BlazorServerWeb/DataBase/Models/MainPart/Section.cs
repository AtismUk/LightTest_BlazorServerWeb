namespace LightTest_BlazorServerWeb.DataBase.Models.MainPart
{
    public class Section : BaseModel
    {
        public string Name { get; set; }
        public int? Section_Id { get; set; }
        public List<Article> Articles { get; set; }
    }
}
