using SehatDoc.Models;

namespace SehatDoc.DTO_s
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int? StateId { get; set; }
        public State? State { get; set; }
        
    }
}
