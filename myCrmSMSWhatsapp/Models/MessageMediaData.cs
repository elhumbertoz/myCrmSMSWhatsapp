using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myCrmSMSWhatsapp.Models
{
    class MessageMediaData
    {
        public int id { get; set; }
        public string mediaKey { get; set; }
        public string data { get; set; }
        public string thumbnail { get; set; }
        public string mimeType { get; set; }
        public string fileName { get; set; }

    }
}
