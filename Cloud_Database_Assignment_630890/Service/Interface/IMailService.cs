using Model.Entity;

namespace Service.Interface
{
    public interface IMailService
    {
        public Task SendMailAsync(User user);
        public Task SendMailToAllUsersAsync();
    }
}
