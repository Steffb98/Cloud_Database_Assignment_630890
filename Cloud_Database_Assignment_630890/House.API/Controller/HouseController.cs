using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;
using Model.DTO;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using System.Net;
using Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Web.Http;
using System.Collections.Generic;

namespace House.API.Controller
{
    public class HouseController
    {
        private readonly ILogger<HouseController> _logger;
        private IHouseService _houseService;

        public HouseController(ILogger<HouseController> log, IHouseService houseService)
        {
            _logger = log;
            _houseService = houseService;
        }

        [FunctionName("CreateHouse")]
        [OpenApiOperation(operationId: "CreateHouse", tags: new[] { "House" })]
        [OpenApiRequestBody("application/json", typeof(HouseDTO), Description = "All the information necessary to create a new house.", Example = typeof(HouseDTOExampleGenerator))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(Guid), Description = "The ID of the house that was made")]
        public async Task<IActionResult> CreateHouse(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            HouseDTO house;
            //trying to parse the json to the object, if unsuccesfull return bad request
            try
            {
                house = JsonConvert.DeserializeObject<HouseDTO>(requestBody);
            }
            catch (JsonSerializationException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            Guid houseID;
            try
            {
                houseID = await _houseService.CreateHouse(house);
            }
            catch (DbUpdateException)
            {
                return new InternalServerErrorResult();
            }
            return new OkObjectResult(houseID);
        }

        [FunctionName("GetAllHouses")]
        [OpenApiOperation(operationId: "GetAllHouses", tags: new[] { "House" })]        
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<Model.Entity.House>), Description = "A list of all houses")]
        public async Task<IActionResult> GetAllHouses(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req)
        {
            List<Model.Entity.House> houses;
            try
            {
                houses = await _houseService.GetAllHouses();
            }
            catch (DbUpdateException)
            {
                return new InternalServerErrorResult();
            }
            return new OkObjectResult(houses);
        }

        [FunctionName("GetAllHousesWithPriceRange")]
        [OpenApiOperation(operationId: "GetAllHouses", tags: new[] { "House" })]
        [OpenApiParameter(name: "lowPriceRange", In = ParameterLocation.Query, Required = true, Type = typeof(double), Description = "The lowest price you want to search for a house")]
        [OpenApiParameter(name: "highPriceRange", In = ParameterLocation.Query, Required = true, Type = typeof(double), Description = "The highest price you want to search for a house")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<Model.Entity.House>), Description = "A list of all houses within a price range")]
        public async Task<IActionResult> GetAllHousesWithPriceRange(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req)
        {
            double lowPriceRange;
            double highPriceRange;
            //trying to parse the json to the object, if unsuccesfull return bad request
            try
            {
                lowPriceRange = double.Parse(req.Query["lowPriceRange"]);
                highPriceRange = double.Parse(req.Query["highPriceRange"]);
            }
            catch (JsonSerializationException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            List<Model.Entity.House> houses;
            try
            {
                houses = await _houseService.GetAllHousesWithPriceRange(lowPriceRange, highPriceRange);
            }
            catch (DbUpdateException)
            {
                return new InternalServerErrorResult();
            }
            return new OkObjectResult(houses);
        }

    }
}
