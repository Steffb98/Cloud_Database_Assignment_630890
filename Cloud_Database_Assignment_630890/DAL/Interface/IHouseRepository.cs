using Model.Entity;

namespace DAL.Interface
{
    public interface IHouseRepository
    {
        public Task CreateHouseAsync(House house);
        public Task<List<House>> GetAllHousesAsync();
        public Task<List<House>> GetAllHousesInPriceRangeAsync(double lowPriceRange, double highPriceRange);
    }
}
