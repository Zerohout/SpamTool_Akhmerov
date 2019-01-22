using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpamTool_Akhmerov.lib.Data;
using SpamTool_Akhmerov.lib.Database;

namespace SpamTool_Akhmerov.lib.Interfaces
{
    public interface IDataService
    {
        IEnumerable<EmailRecipient> GetEmailRecipients();

        IEnumerable<Sender> GetSenders();

        bool UpdateRecipient(EmailRecipient recipient);

        bool CreateRecipient(EmailRecipient recipient);
    }
}
