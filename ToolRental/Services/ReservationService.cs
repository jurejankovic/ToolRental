using ToolRental.Models;
using ToolRental.Repositories.Interfaces;
using ToolRental.Services.Interfaces;

namespace ToolRental.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IToolRepository _toolRepository;
        private readonly IReservationRepository _reservationRepository;
        public ReservationService(IReservationRepository reservationRepository) {
            _reservationRepository = reservationRepository;
        }

        public bool CheckReservationIntervalAsync(DateTime start, DateTime end)
        {
            return _reservationRepository.CheckReservationInterval(start, end);
        }

        public Task CreateReservationAsync(ToolReservation toolReservation)
        {
            return _reservationRepository.CreateReservation(toolReservation);
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
