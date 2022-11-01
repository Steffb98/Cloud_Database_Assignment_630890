using Model.DTO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IHouseService
    {
        public Task CreateHouse(HouseDTO houseDTO);
        public Task<List<House>> GetAllHouses();
        public Task<List<House>> GetAllHousesWithPriceRange(PriceRangeDTO priceRangeDTO);
    }
}
