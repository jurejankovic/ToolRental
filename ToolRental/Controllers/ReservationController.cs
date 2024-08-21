using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToolRental.Helpers;
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
        private readonly UserService _userService;
        public ReservationController(IReservationService reservationService, IToolService toolService, UserService userService) 
        {
            _reservationService = reservationService;
            _toolService = toolService;
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var allTools = await _toolService.GetAllToolsAsync();
            // int reservationId = 1;
            //_reservationService.GetReservationByIdAsync(reservationId);

            ReservationViewModel reservationVM = new ReservationViewModel();

            // priprema drop downa s alatima
            var tools = await _toolService.GetAllToolsAsync();

            // mock data
            //reservationVM.ChosenTool.Name = tools.ElementAt(2).Name;
            //reservationVM.ChosenTool.PricePerHour = tools.ElementAt(2).PricePerHour.ToString("0.00");

            reservationVM.ToolsSelectItems = tools.Take(50).ToList().ConvertAll(tool => new SelectListItem()
            {
                Text = tool.Name,
                Value = tool.Id.ToString()
            }
            );

            return View(reservationVM);
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

        [HttpPost]
        public async Task<IActionResult> SubmitToolReservation([FromForm] ReservationViewModel reservationVM)
        {
            // provjera termina rezervacije
            DateTime start = reservationVM.Start;
            DateTime end = reservationVM.End;
            if (_reservationService.CheckReservationIntervalAsync(start, end))
            {
                var toolReservation = new ToolReservation()
                {
                    RentedTool = reservationVM.ChosenTool.ToModel(),
                    ReservationStart = start,
                    ReservationEnd = end,
                    // trebalo bi vratiti trenutno ulogiranog korisnika kao osobu koja unajmljuje alat
                    ToolRenter = await _userService.GetCurentRenter()
                };

                // spremanje rezervacije
                _reservationService.CreateReservationAsync(toolReservation);
            }
            else
            {
                throw new Exception();
            }

            return RedirectToAction("Index", "Home");
        }

        public JsonResult GetToolDropdownData(string searchString)
        {
            var pagedTools = _toolService.GetAllToolsForDropDown(searchString, 50);
            var data = pagedTools.ToList();

            return Json(data);
        }
    }
}
