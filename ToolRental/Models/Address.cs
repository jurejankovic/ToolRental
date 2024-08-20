using System.Runtime.CompilerServices;

namespace ToolRental.Models
{
    public class Address
    {
        public int Id { get; set; }
        public required string StreetName { get; set; }
        public required string StreetNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
