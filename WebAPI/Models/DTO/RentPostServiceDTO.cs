namespace WebAPI.Models.DTO
{
    public class RentPostServiceDTO
    {
        public int IdrentService { get; set; }
        public int IdrentPost { get; set; }
        public int Idservice { get; set; }
        public ICollection<int> listIdServices { get; set; }=new List<int>();
    }
}
