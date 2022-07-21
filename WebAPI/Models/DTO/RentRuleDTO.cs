namespace WebAPI.Models.DTO
{
    public class RentRuleDTO
    {
        public int IdrentRule { get; set; }
        public int Idrule { get; set; }
        public int IdrentPost { get; set; }
        public ICollection<int> Rules { get; set; }=new List<int>();
    }
}
