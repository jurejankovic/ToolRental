using ToolRental.Models;

namespace ToolRental.Services.Interfaces
{
    public interface IReservationService
    {
        Task CreateReservationAsync(ToolReservation toolReservation);
        Task UpdateReservationAsync(ToolReservation toolReservation);
        Task DeleteReservationByIdAsync(int toolReservationId);
        Task<ToolReservation> GetReservationByIdAsync(int toolReservationId);
        Task<IEnumerable<ToolReservation>> GetAllReservationsAsync();
        bool CheckReservationIntervalAsync(DateTime start, DateTime end);
    }
}
