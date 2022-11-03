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

        public HouseService(IHouseRepository houseRepository, IMailService mailService)
        {
            _houseRepository = houseRepository;
        }

        public async Task<Guid> CreateHouse(HouseDTO houseDTO)
        {
            House house = new()
            {
                HouseID = Guid.NewGuid(),
                Name = houseDTO.Name,
                Price = houseDTO.Price,
                ImageUrl = houseDTO.ImageURL
            };
            await _houseRepository.CreateHouseAsync(house);
            return house.HouseID;
        }

        public async Task<List<House>> GetAllHouses()
        {
            return await _houseRepository.GetAllHousesAsync();
        }

        public async Task<List<House>> GetAllHousesWithPriceRange(double lowPriceRange, double highPriceRange)
        {
            return await _houseRepository.GetAllHousesInPriceRangeAsync(lowPriceRange, highPriceRange);
        }
    }
}
