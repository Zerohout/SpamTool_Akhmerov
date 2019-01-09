using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamTool_Akhmerov.lib.Data
{
    public class MailServers
    {
        public static List<MailServer> Servers { get; } = new List<MailServer>
        {
            new MailServer("smtp.yandex.ru"),
            new MailServer("smtp.mail.ru"),
            new MailServer("smtp.google.com", 125)
        };
    }
}
