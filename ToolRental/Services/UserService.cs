using ToolRental.Models;
using ToolRental.Repositories;
using ToolRental.Repositories.Interfaces;

namespace ToolRental.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ToolRenter> GetCurentRenter()
        {
            return await _userRepository.GetCurentRenter();
        }
    }
}
