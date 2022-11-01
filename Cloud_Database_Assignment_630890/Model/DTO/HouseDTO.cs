using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Resolvers;
using Newtonsoft.Json.Serialization;

namespace Model.DTO
{
    public class HouseDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
    }

    public class HouseDTOExampleGenerator : OpenApiExample<HouseDTO>
    {
        public override IOpenApiExample<HouseDTO> Build(NamingStrategy NamingStrategy)
        {
            Examples.Add(OpenApiExampleResolver.Resolve("House1", new HouseDTO() { Name = "House1", Price = 1.00, ImageURL = "imageurl1" }, NamingStrategy));
            Examples.Add(OpenApiExampleResolver.Resolve("House2", new HouseDTO() { Name = "House2", Price = 2.00, ImageURL = "imageurl2" }, NamingStrategy));
            Examples.Add(OpenApiExampleResolver.Resolve("House3", new HouseDTO() { Name = "House3", Price = 3.00, ImageURL = "imageurl3" }, NamingStrategy));
            return this;
        }
    }
}
