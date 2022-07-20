namespace WebAPI.Models.DTO
{
    public class RentPostDTO
    {
        public int IdrentPost { get; set; }
        public int Uid { get; set; }
        public decimal Price { get; set; }
        public int State { get; set; }
        public DateTime DateCreated { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Coordinates { get; set; } = null!;
    }
}
