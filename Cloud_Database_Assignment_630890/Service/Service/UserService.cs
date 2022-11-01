using DAL;
using DAL.Interface;
using Model.DTO;
using Model.Entity;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateUser(UserDTO userDTO)
        {
            User user = new()
            {
                UserID = Guid.NewGuid(),
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                YearSalary = userDTO.YearSalary
            };

            await _userRepository.CreateUser(user);

            return user.UserID;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task UpdateMortgage(Guid userID, double mortgage)
        {
            await _userRepository.UpdateMortgage(userID, mortgage);
        }
    }
}
