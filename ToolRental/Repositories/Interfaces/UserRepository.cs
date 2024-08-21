using Microsoft.EntityFrameworkCore;
using ToolRental.Data;
using ToolRental.Models;

namespace ToolRental.Repositories.Interfaces
{
    public class UserRepository : IUserRepository
    {
        private ToolRentalContext _dbContext;
        public UserRepository(ToolRentalContext dbContext) {
            _dbContext = dbContext;
        }
        public async Task<ToolRenter> GetCurentRenter()
        {
            return await _dbContext.Renters.FirstAsync();
        }
    }
}
