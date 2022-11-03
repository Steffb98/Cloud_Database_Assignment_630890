using Exceptions.Exceptions;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMortgage.Timer
{
    public class UpdateMortgageController
    {
        private readonly IUserService _userService;

        public UpdateMortgageController(IUserService userService)
        {
            _userService = userService;
        }

        [FunctionName("UpdateMortgageTimeTrigger")]
        public async Task RunAsync([TimerTrigger("0 0 0 * * *")] TimerInfo myTimer, ILogger log)
        {
            try
            {
                await _userService.UpdateMortgageForAllUsersAsync();
            }
            catch (EntityNotFoundException ex)
            {
                log.LogInformation(ex.Message);
            }
        }

    }
}
