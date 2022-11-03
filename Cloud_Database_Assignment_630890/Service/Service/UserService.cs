using DAL.Interface;
using Exceptions.Exceptions;
using Model.DTO;
using Model.Entity;
using Service.Interface;

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

            await _userRepository.CreateUserAsync(user);

            return user.UserID;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsersAsync() ?? throw new EntityNotFoundException("There are no users in the database");
        }

        public async Task UpdateMortgageForAllUsersAsync()
        {
            //getting all users from the database
            List<User> users = await GetAllUsers();

            foreach (User user in users)
            {
                //updating the mortgage for every user
                await CalculateMortgageAsync(user);
            }
        }

        public async Task CalculateMortgageAsync(User user)
        {
            //easy calculation for a mortgage offer
            double mortgage = user.YearSalary * 2.5;

            await _userRepository.UpdateMortgageAsync(user.UserID, mortgage);
        }
    }
}
