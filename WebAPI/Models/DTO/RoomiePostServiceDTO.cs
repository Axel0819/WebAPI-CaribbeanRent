namespace WebAPI.Models.DTO
{
    public class RoomiePostServiceDTO
    {
        public int IdroomieService { get; set; }
        public int IdroomiePost { get; set; }
        public int Idservice { get; set; }
        public ICollection<int> listIdServices { get; set; } = new List<int>();
    }
}
