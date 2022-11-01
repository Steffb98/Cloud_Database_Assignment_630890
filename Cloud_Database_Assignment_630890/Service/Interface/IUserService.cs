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
        public Task CreateUser(UserDTO userDTO);
        public Task<List<User>> GetAllUsers();
        public Task UpdateMortgage(Guid userID, double mortgage);
    }
}
