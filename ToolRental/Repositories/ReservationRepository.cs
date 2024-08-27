using Microsoft.EntityFrameworkCore;
using ToolRental.Data;
using ToolRental.Models;
using ToolRental.Repositories.Interfaces;

namespace ToolRental.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private ToolRentalContext _dbContext;

        public ReservationRepository(ToolRentalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CheckReservationInterval(DateTime start, DateTime end)
        {
            return _dbContext.ToolReservation.Where(ri => ri.ReservationStart > start && ri.ReservationEnd < end).Any();
        }

        public async Task<ToolReservation> CreateReservation(ToolReservation reservation)
        {
            await _dbContext.ToolReservation.AddAsync(reservation);
            int count = _dbContext.SaveChanges();
            return null;
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
