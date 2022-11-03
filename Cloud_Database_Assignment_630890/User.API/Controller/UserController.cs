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


namespace User.API.Controller
{
    public class UserController
    {
        private readonly ILogger<UserController> _logger;
        private IUserService _userService;

        public UserController(ILogger<UserController> log, IUserService userService)
        {
            _logger = log;
            _userService = userService;
        }

        [FunctionName("CreateUser")]
        [OpenApiOperation(operationId: "CreateUser", tags: new[] { "User" })]
        [OpenApiRequestBody("application/json", typeof(UserDTO), Description = "All the information necessary to create a new user.", Example = typeof(UserDTO))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(Guid), Description = "The ID of the user that was made")]
        public async Task<IActionResult> CreateUser(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            UserDTO user;
            //trying to parse the json to the object, if unsuccesfull return bad request
            try
            {
                user = JsonConvert.DeserializeObject<UserDTO>(requestBody);
            }
            catch (JsonSerializationException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            Guid userID;
            try
            {
                userID = await _userService.CreateUser(user);
            }
            catch (DbUpdateException)
            {
                return new InternalServerErrorResult();
            }
            return new OkObjectResult(userID);
        }

        [FunctionName("GetAllUsers")]
        [OpenApiOperation(operationId: "GetAllUsers", tags: new[] { "User" })]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<Model.Entity.User>), Description = "A list of all users")]
        public async Task<IActionResult> GetAllUsers(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req)
        {
            List<Model.Entity.User> users;
            try
            {
                users = await _userService.GetAllUsers();
            }
            catch (DbUpdateException)
            {
                return new InternalServerErrorResult();
            }
            return new OkObjectResult(users);
        }
    }
}
