using System.ComponentModel.DataAnnotations;

namespace ToolRental.Models
{
    public class ToolRenter : Person
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
