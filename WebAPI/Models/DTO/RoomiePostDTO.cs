namespace WebAPI.Models.DTO
{
    public class RoomiePostDTO
    {
        public int IdroomiePost { get; set; }
        public int Uid { get; set; }
        public int Room { get; set; }
        public string Ubication { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public string Description { get; set; } = null!;
        public DateTime? UpdatePost { get; set; }
        public int? State { get; set; }

    }
}
