using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myCrmSMSWhatsapp
{
    class LoginData
    {
        public string token { get; set; }
        public DateTime sessionExpire { get; set; }
        public string userId { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string userName { get; set; }
        public string phoneNumber { get; set; }
        public string domainId { get; set; }
        public bool super { get; set; }
        public bool @operator { get; set; }
        public string domainName { get; set; }
        public DateTime expire { get; set; }
        public bool useZabbix { get; set; }
        public string zabbixServerUrl { get; set; }
        public string zabbixUserName { get; set; }
        public string zabbixPassword { get; set; }
        public bool demo { get; set; }
        public bool crmAcess { get; set; }
        public string phoneLocalPrefix { get; set; }
        public string phoneCountryPrefix { get; set; }
    }
}
