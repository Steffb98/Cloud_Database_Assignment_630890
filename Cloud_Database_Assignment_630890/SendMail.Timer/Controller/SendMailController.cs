using Service.Interface;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
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
