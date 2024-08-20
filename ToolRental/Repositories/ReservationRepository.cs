using ToolRental.Models;
using ToolRental.Repositories.Interfaces;

namespace ToolRental.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public Task<ToolReservation> CreateReservation(ToolReservation reservation)
        {
            throw new NotImplementedException();
        }

        public Task<ToolReservation> DeleteReservation(int reservationId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToolReservation>> GetAllReservations()
        {
            throw new NotImplementedException();
        }

        public Task<ToolReservation> GetReservationById(int eservationId)
        {
            throw new NotImplementedException();
        }

        public Task<ToolReservation> UpdateReservation(ToolReservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
