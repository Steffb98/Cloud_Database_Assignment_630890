using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Resolvers;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class PriceRangeDTO 
    { 
        public double LowPriceRange { get; set; }
        public double HighPriceRange { get; set; }
    }

    public class PriceRangeDTOExampleGenerator : OpenApiExample<PriceRangeDTO>
    {
        public override IOpenApiExample<PriceRangeDTO> Build(NamingStrategy NamingStrategy)
        {
            Examples.Add(OpenApiExampleResolver.Resolve("PriceRange1", new PriceRangeDTO() { LowPriceRange = 1.00, HighPriceRange = 2.00 }, NamingStrategy));
            Examples.Add(OpenApiExampleResolver.Resolve("PriceRange2", new PriceRangeDTO() { LowPriceRange = 2.00, HighPriceRange = 3.00 }, NamingStrategy));
            Examples.Add(OpenApiExampleResolver.Resolve("PriceRange3", new PriceRangeDTO() { LowPriceRange = 3.00, HighPriceRange = 4.00 }, NamingStrategy));
            return this;
        }
    }

}
