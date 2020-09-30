using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Interface
{
    public interface IMailSender
    {
        void SendMail(Message message);
        Task SendMailAsync(Message message);
    }
}
