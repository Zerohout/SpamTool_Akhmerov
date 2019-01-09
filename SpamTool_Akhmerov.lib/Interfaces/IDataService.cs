using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpamTool_Akhmerov.lib.Database;

namespace SpamTool_Akhmerov.lib.Interfaces
{
    public interface IDataService
    {
        IEnumerable<EmailRecipients> GetEmailRecipients();

        bool UpdateRecipient(EmailRecipients recipient);

        bool CreateRecipient(EmailRecipients recipient);
    }
}
