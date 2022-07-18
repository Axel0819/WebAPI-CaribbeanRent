namespace WebAPI.Models.DTO
{
    public class UserCrDTO
    {
        public int Uid { get; set; }
        public string Name { get; set; } = null!;
        public string FirstSurname { get; set; } = null!;
        public string SecondSurname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Role { get; set; }
        public int State { get; set; }
    }
}
