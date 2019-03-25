using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Communication
{
    public class EmailSenderService : IEmailSenderService
    {
        public EmailSendResult Send(EmailMessageModel emailMessageModel)
        {
            var message = new MailMessage();
            foreach (var item in emailMessageModel.Receiver)
            {
                message.To.Add(new MailAddress(item));
            }
            message.From = new MailAddress("teberonur11@gmail.com");
            message.Subject = emailMessageModel.Subject;
            message.Body = emailMessageModel.MessageBody;
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            var credential = new NetworkCredential
            {
                UserName = "teberonur11@gmail.com",
                Password = "matematik123"                
            };
            smtp.Credentials = credential;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;//25 dene
            smtp.EnableSsl = true;
            smtp.Send(message);
            return EmailSendResult.Successful;
        }
    }
}
