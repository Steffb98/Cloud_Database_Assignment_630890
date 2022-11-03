using Model.DTO;
using Model.Entity;

namespace Service.Interface
{
    public interface IUserService
    {
        public Task<Guid> CreateUser(UserDTO userDTO);
        public Task<List<User>> GetAllUsers();
        public Task UpdateMortgageForAllUsersAsync();
        public Task CalculateMortgageAsync(User user);
    }
}
