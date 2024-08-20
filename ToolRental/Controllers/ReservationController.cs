using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToolRental.Models;
using ToolRental.Services;
using ToolRental.Services.Interfaces;
using ToolRental.ViewModels;

namespace ToolRental.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IToolService _toolService;
        public ReservationController(IReservationService reservationService, IToolService toolService) 
        {
            _reservationService = reservationService;
            _toolService = toolService;
        }
        public async Task<IActionResult> Index()
        {
            var allTools = await _toolService.GetAllToolsAsync();
            // int reservationId = 1;
            //_reservationService.GetReservationByIdAsync(reservationId);

            ReservationViewModel reservationVM = new ReservationViewModel();
            
            // priprema drop downa s alatima
            var tools = await _toolService.GetAllToolsAsync();
            reservationVM.ToolsSelectItems = tools.Take(50).ToList().ConvertAll(tool => new SelectListItem()
            {
                Text = tool.Name,
                Value = tool.Id.ToString()    
            }
            );

            return View(reservationVM);
        }

        public JsonResult GetToolDropdownData(string searchString)
        {
            var pagedTools = _toolService.GetAllToolsForDropDown(searchString, 50);
            var data = pagedTools.ToList();
            
            return Json(data);
        }

        public async Task<Tool> Get(int toolId)
        {
            var tool = await _toolService.GetToolByIdAsync(toolId);
            if (tool != null)
            {
                return null;
            }
            return tool;
        }
    }
}
