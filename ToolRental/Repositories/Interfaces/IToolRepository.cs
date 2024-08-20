using ToolRental.Models;

namespace ToolRental.Repositories.Interfaces
{
    public interface IToolRepository
    {
        Task<Tool> GetTool(int toolId);
        Task<IEnumerable<Tool>> GetAllTools();
        Task<IEnumerable<Tool>> GetAllToolsPaged(int pageNumber, int pageSize);
        Task<Tool> UpdateToolReservation(int toolId);
        IEnumerable<dynamic> GetAllToolsForDropDown(string searchString, int pageSize);
    }
}
