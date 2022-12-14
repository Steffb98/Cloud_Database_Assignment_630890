using DAL.Interface;
using Exceptions.Exceptions;
using Microsoft.EntityFrameworkCore;
using Model.Entity;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _dbContext;
        public UserRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateUserAsync(User user)
        {
            //first we add the user to the table
            await _dbContext.Users.AddAsync(user);
            //then we update the database to sync
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            //returning a list of all users in the database
            List<User> users =  await _dbContext.Users
                .ToListAsync();

            if(users.Count == 0)
            {
                throw new EntityNotFoundException("There are no users found in the database");
            }

            return users;
        }

        public async Task UpdateMortgageAsync(Guid userID, double mortgage)
        {
            //finding the card that should be updated.
            User userToUpdate = await _dbContext.Users
                .Where(u => u.UserID == userID)
                .FirstOrDefaultAsync() ?? throw new EntityNotFoundException("Could not find a user with this ID");
            //updating the card that should be updated with the new values.           
            userToUpdate.MortgageOffer = mortgage;

            //The ChangeTracker will automatically see the entry is updated, so saving to the database will update the specific row.
            await _dbContext.SaveChangesAsync();
        }
    }
}
