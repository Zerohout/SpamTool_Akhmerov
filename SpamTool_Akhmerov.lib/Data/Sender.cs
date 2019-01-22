using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamTool_Akhmerov.lib.Data
{
    public class Sender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ICollection<Recipient> Recipients { get; set; }
        public ICollection<Mail> Mails { get; set; }
    }
}
