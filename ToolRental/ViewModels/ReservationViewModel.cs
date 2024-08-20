using Microsoft.AspNetCore.Mvc.Rendering;
using ToolRental.Models;

namespace ToolRental.ViewModels
{
    public class ReservationViewModel
    {
        public ReservationViewModel() { }
       
        public List<ToolViewModel> Tools = new List<ToolViewModel>();
        public List<SelectListItem> ToolsSelectItems = new List<SelectListItem>();
        public List<Tool> PagedTools = new List<Tool>();
        public int TotalPages;
        public int CurrentPage;
    }
}
