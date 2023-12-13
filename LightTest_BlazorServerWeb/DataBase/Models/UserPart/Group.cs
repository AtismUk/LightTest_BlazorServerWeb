namespace LightTest_BlazorServerWeb.DataBase.Models.UserPart
{
    public class Group : BaseModel
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
