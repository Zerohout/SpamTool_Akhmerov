using System;
using System.Collections.Generic;

namespace SpamTool_Akhmerov.lib.Data
{
    public class SchedulerTask
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public IEnumerable<Recipient> Recipients { get; set; }

        public MailServer Server { get; set; }
        public Sender Sender { get; set; }
        public Mail Mail { get; set; }

    }
}
