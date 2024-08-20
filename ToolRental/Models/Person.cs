namespace ToolRental.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Oib { get; set; }
        public required Address Address { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }

    }
}
