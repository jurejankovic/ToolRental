using ToolRental.Models;
using ToolRental.Repositories.Interfaces;

namespace ToolRental.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public async Task<ToolRenter> GetCurentRenter()
        {
            return await _userRepository.GetCurentRenter();
        }
    }
}
