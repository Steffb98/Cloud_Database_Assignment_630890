using Model.DTO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
