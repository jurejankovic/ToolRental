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

        public bool CheckReservationInterval(DateTime start, DateTime end, int toolId)
        {
            return _dbContext.ToolReservation
                .Where(t => t.RentedTool.Id == toolId)
                .Any(ri => ri.ReservationStart < end && ri.ReservationEnd > start);
        }

        public async Task<int> CreateReservation(ToolReservation reservation)
        {
            await _dbContext.ToolReservation.AddAsync(reservation);
            int count = _dbContext.SaveChanges();
            return count;
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
