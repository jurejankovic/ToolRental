using System.ComponentModel.DataAnnotations.Schema;

namespace ToolRental.Models
{
    public class Tool 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        
        [Column(TypeName="money")]
        public decimal PricePerHour { get; set; }
    }
}
