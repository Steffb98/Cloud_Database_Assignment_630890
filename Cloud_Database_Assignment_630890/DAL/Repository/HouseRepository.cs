using DAL.Interface;
using Exceptions.Exceptions;
using Microsoft.EntityFrameworkCore;
using Model.Entity;

namespace DAL.Repository
{
    public class HouseRepository : IHouseRepository
    {
        private readonly DBContext _dbContext;
        public HouseRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateHouse(House house)
        {
            //first we add the user to the table
            await _dbContext.Houses.AddAsync(house);
            //then we update the database to sync
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<House>> GetAllHouses()
        {
            //returning a list of all houses in the database
            return await _dbContext.Houses
                .ToListAsync() ?? throw new EntityNotFoundException("There are no users in the database");
        }

        public async Task<List<House>> GetAllHousesInPriceRange(double lowPriceRange, double highPriceRange)
        {
            //returns a list of all houses in the database within the price range.
            return await _dbContext.Houses
                .Where( h => h.Price >= lowPriceRange && h.Price <= highPriceRange)
                .ToListAsync() ?? throw new EntityNotFoundException("There are no users in the database");
        }
    }
}
