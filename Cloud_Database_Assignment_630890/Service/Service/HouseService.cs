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
    public class HouseService : IHouseService
    {

        private readonly IHouseRepository _houseRepository;

        public HouseService(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        public async Task CreateHouse(HouseDTO houseDTO)
        {
            House house = new()
            {
                HouseID = Guid.NewGuid(),
                Name = houseDTO.Name,
                Price = houseDTO.Price,
                ImageUrl = houseDTO.ImageURL
            };
            await _houseRepository.CreateHouse(house);
        }

        public async Task<List<House>> GetAllHouses()
        {
            return await _houseRepository.GetAllHouses();
        }

        public async Task<List<House>> GetAllHousesWithPriceRange(PriceRangeDTO priceRangeDTO)
        {
            return await _houseRepository.GetAllHousesInPriceRange(priceRangeDTO.LowPriceRange, priceRangeDTO.HighPriceRange);
        }
    }
}
