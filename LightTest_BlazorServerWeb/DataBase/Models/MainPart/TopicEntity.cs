namespace LightTest_BlazorServerWeb.DataBase.Models.MainPart
{
    public class TopicEntity : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? imgGuid { get; set; }
        public string? Icon { get; set; }
    }
}
