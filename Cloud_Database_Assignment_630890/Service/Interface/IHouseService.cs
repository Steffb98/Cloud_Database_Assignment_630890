using Model.DTO;
using Model.Entity;

namespace Service.Interface
{
    public interface IHouseService
    {
        public Task<Guid> CreateHouse(HouseDTO houseDTO);
        public Task<List<House>> GetAllHouses();
        public Task<List<House>> GetAllHousesWithPriceRange(double lowPriceRange, double highPriceRange);
    }
}
