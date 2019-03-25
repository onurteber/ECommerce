using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Communication
{
    public enum EmailSendResult
    {
        Successful = 1,
        NotAuthorized = 2,
        RequiredSsl = 3,
        Failed = -1
    }
}
