namespace ToolRental.Models
{
    public class ToolReservation
    {
        public int Id { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }

        public Tool RentedTool { get; set; }
        public ToolRenter ToolRenter { get; set; }
    }
}
