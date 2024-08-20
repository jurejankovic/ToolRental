namespace ToolRental.ViewModels
{
    public class ToolViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PricePerHour { get; set; }
        public bool Checked { get; set; } = false;
    }
}
