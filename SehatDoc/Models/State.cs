using SehatDoc.DoctorEnums;

namespace SehatDoc.Models
{
    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public ICollection<City>? Cities { get; set; }
    }
}
