using ToolRental.Models;

namespace ToolRental.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<ToolRenter> GetCurentRenter();
    }
}