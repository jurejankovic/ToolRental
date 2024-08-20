using ToolRental.Models;

namespace ToolRental.Services.Interfaces
{
    public interface IToolService
    {
        Task<Tool> GetToolByIdAsync(int toolId);
        Task<IEnumerable<Tool>> GetAllToolsAsync();
        Task<IEnumerable<Tool>> GetAllToolsPagedAsync(int pageNumber, int pageSize);
        IEnumerable<dynamic> GetAllToolsForDropDown(string searchString, int pageSize);
        Task<Tool> UpdateToolReservationAsync(int toolId);
    }
}
