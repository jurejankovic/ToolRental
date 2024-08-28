using Microsoft.AspNetCore.Mvc;
using ToolRental.Models;
using ToolRental.Services.Interfaces;

namespace ToolRental.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsApiController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IToolService _toolService;
        public ReservationsApiController(IReservationService reservationService, IToolService toolService)
        {
            _reservationService = reservationService;
            _toolService = toolService;
        }
        
        [HttpGet("GetToolDropdownData")]
        public JsonResult GetToolDropdownData(string searchString)
        {
            var pagedTools = _toolService.GetAllToolsForDropDown(searchString, 50);
            var data = pagedTools.ToList();

            return new JsonResult(data);
        }

        [HttpGet("CheckToolReservationInterval")]
        public JsonResult CheckToolReservationInterval(string startTime, string endTime, string toolIdString)
        {
            DateTime start = DateTime.Parse(startTime);
            DateTime end = DateTime.Parse(endTime);
            int.TryParse(toolIdString, out int toolId);

            bool isIntervalFree = _reservationService.CheckReservationIntervalAsync(start, end, toolId);
            var data = isIntervalFree;

            return new JsonResult(data);
        }
    }
}
