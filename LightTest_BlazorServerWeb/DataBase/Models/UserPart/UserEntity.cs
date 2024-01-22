namespace LightTest_BlazorServerWeb.DataBase.Models.UserPart
{
    public class UserEntity : BaseModel
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
        public List<GroupEntity> Groups { get; set; }
    }
}
