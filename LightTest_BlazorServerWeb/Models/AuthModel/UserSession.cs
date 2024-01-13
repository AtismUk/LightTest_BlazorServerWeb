namespace LightTest_BlazorServerWeb.Models.AuthModel
{
    public class UserSession
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public List<int> groupsId { get; set; }
        public bool isAdmin { get; set; }
    }
}
