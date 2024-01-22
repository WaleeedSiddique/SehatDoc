using SehatDoc.Models;

namespace SehatDoc.DTO_s
{
    public class StateDTO
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public ICollection<City>? Cities { get; set; }
    }
}
