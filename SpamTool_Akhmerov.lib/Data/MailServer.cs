using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamTool_Akhmerov.lib.Data
{
    public class MailServer
    {
        public string Address { get; set; }
        public int Port { get; set; } = 25;
        public bool UseSSL { get; set; } = true;

        public MailServer()
        {
            
        }

        public MailServer(string Address, int Port = 25, bool UseSSL = true)
        {
            this.Address = Address;
            this.Port = Port;
            this.UseSSL = UseSSL;
        }
    }
}
