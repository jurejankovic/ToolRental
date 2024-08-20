using ToolRental.Models;
using ToolRental.Repositories;
using ToolRental.Repositories.Interfaces;
using ToolRental.Services.Interfaces;

namespace ToolRental.Services
{
    public class ToolService : IToolService
    {
        private readonly IToolRepository _toolRepository;

        public ToolService(IToolRepository toolRepository) 
        {
            _toolRepository = toolRepository;
        }

        public async Task<IEnumerable<Tool>> GetAllToolsAsync()
        {
            return await _toolRepository.GetAllTools();
        }

        public IEnumerable<dynamic> GetAllToolsForDropDown(string searchString, int pageSize)
        {
            if (searchString != null)
                return _toolRepository.GetAllToolsForDropDown(searchString, pageSize);
            else
                return [];
        }

        public async Task<IEnumerable<Tool>> GetAllToolsPagedAsync(int pageNumber, int pageSize)
        {
            return await _toolRepository.GetAllToolsPaged(pageNumber, pageSize);
        }

        public async Task<Tool> GetToolByIdAsync(int toolId)
        {
            var tool = await _toolRepository.GetTool(toolId);
            return tool;
        }

        public Task<Tool> UpdateToolReservationAsync(int toolId)
        {
            throw new NotImplementedException();
        }
    }
}
