﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamTool_Akhmerov.lib.Data
{
    public class Mail
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public Sender Sender { get; set; }
        public MailServer MailServer { get; set; }

        public ICollection<Recipient> Recipients { get; set; }
    }
}
