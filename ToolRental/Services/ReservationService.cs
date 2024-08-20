using ToolRental.Models;
using ToolRental.Repositories.Interfaces;
using ToolRental.Services.Interfaces;

namespace ToolRental.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IToolRepository _toolRepository;
        private readonly IReservationRepository _reservationRepository;
        public ReservationService() { }

        public Task<ToolReservation> CheckReservationIntervalAsync(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task CreateReservationAsync(ToolReservation toolReservation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReservationByIdAsync(int toolReservationId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToolReservation>> GetAllReservationsAsync()
        {
            return _reservationRepository.GetAllReservations();
        }

        public Task<ToolReservation> GetReservationByIdAsync(int reservationId)
        {
            return _reservationRepository.GetReservationById(reservationId);
        }

        public Task UpdateReservationAsync(ToolReservation toolReservation)
        {
            throw new NotImplementedException();
        }
    }
}
