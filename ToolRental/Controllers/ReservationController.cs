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
            int seletedToolId = reservationVM.SelectedToolId;

            if (!_reservationService.CheckReservationIntervalAsync(start, end, seletedToolId))
            {
                var toolReservation = new ToolReservation()
                {
                    RentedTool = await _toolService.GetToolByIdAsync(seletedToolId),
                    ReservationStart = start,
                    ReservationEnd = end,
                    // trebalo bi vratiti trenutno ulogiranog korisnika kao osobu koja unajmljuje alat
                    ToolRenter = await _userService.GetCurentRenter()
                };

                // pokušaj spremanja rezervacije
                if (await _reservationService.CreateReservationAsync(toolReservation))
                {
                    // uspješno spremanje
                    return RedirectToAction("Success");
                }
                else
                {
                    // greška pri spremanju
                    return RedirectToAction("Error");
                }
            }
            else
            {
                return RedirectToAction("Error");
            }

        }

        public async Task<IActionResult> Success()
        {
            return View();
        }
        public async Task<IActionResult> Error()
        {
            return View();
        }

    }
}
