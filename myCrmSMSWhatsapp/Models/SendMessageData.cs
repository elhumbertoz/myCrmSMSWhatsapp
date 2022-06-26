using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myCrmSMSWhatsapp.Models
{
    class SendMessageData
    {
        public string userId { get; set; }
        public string whatsAppContactId { get; set; }
        public string message { get; set; }
        public string caption { get; set; }
        public string mimeType { get; set; }
        public string media { get; set; }
        public string fileName { get; set; }
        public bool messageBase64 { get; set; }
        public string quotedMessageId { get; set; }
    }
}
