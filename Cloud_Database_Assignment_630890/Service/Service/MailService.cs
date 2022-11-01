using Azure.Communication.Email;
using Azure.Communication.Email.Models;
using Model.Entity;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class MailService : IMailService
    {
        private static readonly string? connection = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
        EmailClient emailClient;
        public MailService()
        {
            emailClient = new EmailClient(connection);
        }

        public async Task SendMail(User user)
        {
            //not tested yet
            EmailContent emailContent = new EmailContent("This is a test 1");
            emailContent.PlainText = "This is a test 2";
            List<EmailAddress> emailAddresses = new List<EmailAddress> { new EmailAddress("630890@student.inholland.nl") { DisplayName = "630890" } };
            EmailRecipients emailRecipients = new EmailRecipients(emailAddresses);
            EmailMessage emailMessage = new EmailMessage("af8df88e-626e-4941-b811-311189b9cbef.azurecomm.net", emailContent, emailRecipients);
            await emailClient.SendAsync(emailMessage);
        }
    }
}
