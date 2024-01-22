namespace LightTest_BlazorServerWeb.DataBase.Models.UserPart
{
    public class GroupEntity : BaseModel
    {
        public string Name { get; set; }
        public List<UserEntity> Users { get; set; }
    }
}
