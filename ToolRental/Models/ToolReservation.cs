using Microsoft.EntityFrameworkCore;

namespace ToolRental.Models
{
    public class ToolReservation
    {
        public int Id { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }

        public ICollection<Tool> RentedTools { get; set; }
        public ICollection<ToolRenter> ToolRenters { get; set; }
    }
}
