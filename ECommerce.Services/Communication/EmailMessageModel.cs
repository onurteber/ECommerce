using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Communication
{
    public class EmailMessageModel
    {
        public EmailMessageModel()
        {
            Receiver = new List<string>();
        }
        public List<string> Receiver { get; set; }
        public string MessageBody { get; set; }
        public string Subject { get; set; }
    }
}
