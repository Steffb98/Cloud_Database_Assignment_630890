using Model.Entity;

namespace DAL.Interface
{
    public interface IUserRepository
    {
        public Task CreateUserAsync(User user);
        public Task UpdateMortgageAsync(Guid userID, double mortgage);
        public Task<List<User>> GetAllUsersAsync();
    }
}
