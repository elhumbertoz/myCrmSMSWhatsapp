using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myCrmSMSWhatsapp
{
    class AckMessageData
    {
        public string whatsAppMessageUniqueId { get; set; }
        public int ack { get; set; }
    }
}
