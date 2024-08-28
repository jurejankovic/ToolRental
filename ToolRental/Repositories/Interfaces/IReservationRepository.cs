using ToolRental.Models;

namespace ToolRental.Repositories.Interfaces
{
    public interface IReservationRepository
    {
        Task<int> CreateReservation(ToolReservation reservation);
        Task<ToolReservation> UpdateReservation(ToolReservation reservation);
        Task<ToolReservation> DeleteReservation(int reservationId);
        Task<ToolReservation> GetReservationById(int eservationId);
        Task<IEnumerable<ToolReservation>> GetAllReservations();
        bool CheckReservationInterval(DateTime start, DateTime end, int toolId);
    }
}
