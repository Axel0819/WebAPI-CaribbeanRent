namespace WebAPI.Models.DTO
{
    public class ImageDTO
    {
        public int Idimage { get; set; }
        public int IdrentPost { get; set; }
        public string? Urlimage { get; set; }
        public ICollection<IFormFile> Files { get; set; } = new List<IFormFile>();
    }
}
