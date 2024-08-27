using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolRental.Data;
using ToolRental.Models;
using ToolRental.Repositories.Interfaces;
using ToolRental.Services.Interfaces;

namespace ToolRental.Repositories
{
    public class ToolRepository : IToolRepository
    {
        private ToolRentalContext _dbContext;

        public ToolRepository(ToolRentalContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Tool>> GetAllTools()
        {
            return await _dbContext.Tool.ToListAsync();
        }

        public IEnumerable<dynamic> GetAllToolsForDropDown(string searchString, int pageSize)
        {
            return _dbContext.Tool.Where(item => item.Name.ToLower().Contains(searchString.ToLower()))
                .Select(item => new
                {
                    Value = item.Id,
                    Text = item.Name,
                    Desc = item.Description,
                    PricePerHour = item.PricePerHour
                })
                .Take(pageSize)
                .ToList();
        }

        public async Task<IEnumerable<Tool>> GetAllToolsPaged(int pageNumber = 1, int pageSize = 10)
        {
            return await _dbContext.Tool.OrderBy(d => d.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Tool> GetTool(int toolId)
        {
            return await _dbContext.Tool.FindAsync(toolId);
        }

        public Task<Tool> UpdateToolReservation(int toolId)
        {
            throw new NotImplementedException();
        }
    }
}