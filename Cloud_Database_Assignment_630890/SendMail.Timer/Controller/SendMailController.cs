using Service.Interface;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Model.Entity;
using Microsoft.Extensions.Logging;
using System;
using Exceptions.Exceptions;

namespace SendMail.Timer.Controller
{
    public class SendMailController
    {
        private readonly IMailService _mailService;

        public SendMailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [FunctionName("SendMailsTimeTrigger")]
        public async Task RunAsync([TimerTrigger("0 0 6 * * *")] TimerInfo myTimer, ILogger log)
        {
            try
            {
                await _mailService.SendMailToAllUsersAsync();
            }catch(EntityNotFoundException ex)
            {
                log.LogInformation(ex.Message);
            }
        }
    }
}
