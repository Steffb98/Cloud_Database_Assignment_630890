using Azure.Communication.Email;
using Azure.Communication.Email.Models;
using Model.Entity;
using Service.Interface;

namespace Service.Service
{
    public class MailService : IMailService
    {
        private static readonly string? connection = Environment.GetEnvironmentVariable("EmailConnectionString");
        private readonly IUserService _userService;

        EmailClient emailClient;
        public MailService(IUserService userService)
        {
            emailClient = new EmailClient(connection);
            _userService = userService;
        }

        public async Task SendMailToAllUsersAsync()
        {
            //getting all users from the database
            List<User> users = await _userService.GetAllUsers();

            foreach (User user in users)
            {
                if(user.MortgageOffer != null)
                {
                    await SendMailAsync(user);
                }
            }

        }

        public async Task SendMailAsync(User user)
        {
            //setting the subject of the email
            EmailContent emailContent = new EmailContent("Mortgage offer update");
            //the body of the email
            emailContent.PlainText = $"Hi {user.FirstName} {user.LastName}, your mortgage has been calculated. According to your yearly income of {user.YearSalary}, your mortgage offer would be {user.MortgageOffer}. Kind regards, BuyMyHouse";
            //the recipient of the email
            List<EmailAddress> emailAddresses = new List<EmailAddress> { new EmailAddress(user.Email) { DisplayName = user.FirstName } };
            EmailRecipients emailRecipients = new EmailRecipients(emailAddresses);
            EmailMessage emailMessage = new EmailMessage("DoNotReply@af8df88e-626e-4941-b811-311189b9cbef.azurecomm.net", emailContent, emailRecipients);
            await emailClient.SendAsync(emailMessage);
        }
    }
}
