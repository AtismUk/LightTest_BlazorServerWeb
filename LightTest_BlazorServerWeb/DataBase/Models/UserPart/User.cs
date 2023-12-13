namespace LightTest_BlazorServerWeb.DataBase.Models.UserPart
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
        public List<Group> Groups { get; set; }
    }
}
