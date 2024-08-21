using Microsoft.AspNetCore.Mvc;
using ToolRental.Models;
using ToolRental.Services.Interfaces;
using ToolRental.ViewModels;

namespace ToolRental.Controllers
{
    // TODO: ovo treba pretvoriti u neki pregled rezervacija
    public class ToolOverviewController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IToolService _toolService;

        public ToolOverviewController(IReservationService reservationService, IToolService toolService)
        {
            _reservationService = reservationService;
            _toolService = toolService;
        }

        public async Task<IActionResult> Index(string searchString, string currentFilter, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var tools = LoadTools().Result;
            if (!string.IsNullOrEmpty(searchString))
            {
                tools = tools.Where(t => t.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var pagedTools = await _toolService.GetAllToolsPagedAsync(pageNumber, pageSize);


            ReservationViewModel reservationVM = new ReservationViewModel();

            foreach (var pagedTool in pagedTools)
            {
                var toolVM = new ToolViewModel()
                {
                    Id = pagedTool.Id.ToString(),
                    Name = pagedTool.Name,
                    Description = pagedTool.Description,
                    PricePerHour = Math.Round(pagedTool.PricePerHour, 2).ToString(),
                };
                reservationVM.Tools.Add(toolVM);
            }
            reservationVM.CurrentPage = pageNumber;
            reservationVM.TotalPages = 10;

            return View(reservationVM);
        }

        private async Task<IEnumerable<Tool>> LoadTools()
        {
            return await _toolService.GetAllToolsAsync();
        }
    }
}
