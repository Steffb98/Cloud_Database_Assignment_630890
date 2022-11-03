using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Resolvers;
using Newtonsoft.Json.Serialization;

namespace Model.DTO
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public double YearSalary { get; set; }
    }

    public class UserDTOExampleGenerator : OpenApiExample<UserDTO>
    {
        public override IOpenApiExample<UserDTO> Build(NamingStrategy NamingStrategy)
        {
            Examples.Add(OpenApiExampleResolver.Resolve("User1", new UserDTO() { FirstName = "FirstName1", LastName = "LastName1", Email = "Email1", YearSalary = 1.00 }, NamingStrategy));
            Examples.Add(OpenApiExampleResolver.Resolve("User2", new UserDTO() { FirstName = "FirstName2", LastName = "LastName2", Email = "Email2", YearSalary = 2.00 }, NamingStrategy));
            Examples.Add(OpenApiExampleResolver.Resolve("User3", new UserDTO() { FirstName = "FirstName3", LastName = "LastName3", Email = "Email3", YearSalary = 3.00 }, NamingStrategy));
            return this;
        }
    }
}
