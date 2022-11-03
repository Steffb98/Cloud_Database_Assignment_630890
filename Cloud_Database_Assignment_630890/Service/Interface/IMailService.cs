using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;

namespace Service.Interface
{
    public interface IMailService
    {
        public Task SendMailAsync(User user);
        public Task SendMailToAllUsersAsync();
    }
}
