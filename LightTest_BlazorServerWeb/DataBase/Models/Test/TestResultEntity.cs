using LightTest_BlazorServerWeb.DataBase.Models.UserPart;

namespace LightTest_BlazorServerWeb.DataBase.Models.Test
{
    public class TestResultEntity : BaseModel
    {
        public int testId { get; set; }
        public int userId { get; set; }
        public int Score { get; set; }
        public DateTime Time { get; set; }
        public TestEntity Test { get; set; }
        public UserEntity User { get; set; }
        public List<AnswerResultEntity> AnswerResults { get; set; }
    }
}
