using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Communication
{
    public interface IEmailSenderService
    {
        EmailSendResult Send(EmailMessageModel emailMessageModel);
    }
}
