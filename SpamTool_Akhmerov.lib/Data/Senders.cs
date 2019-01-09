using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpamTool_Akhmerov.lib.Service;

namespace SpamTool_Akhmerov.lib.Data
{
    public class Senders
    {
        public static List<Sender> List { get; } = new List<Sender>
        {
            new Sender { Name = "Profi", Address = "zerohout@gmail.com", Password = PasswordService.Encode("P@ssW0rd")},
            new Sender { Name = "User", Address = "zerohout@yandex.ru", Password = PasswordService.Encode("dr0Wss@P") },
            new Sender { Name = "Lamer", Address = "trankien@yandex.ru", Password = PasswordService.Encode("W0rdP@ss") },
        };
    }
}
