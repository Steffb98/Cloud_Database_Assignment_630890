using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;

namespace DAL.Interface
{
    public interface IHouseRepository
    {
        public Task CreateHouse(House house);
        public Task<List<House>> GetAllHouses();
        public Task<List<House>> GetAllHousesInPriceRange(double priceRangeLow, double priceRangeHigh);
    }
}
