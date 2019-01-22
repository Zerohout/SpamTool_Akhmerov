using SpamTool_Akhmerov.lib.Data;
using System.Collections.Generic;

namespace SpamTool_Akhmerov.lib.Interfaces
{
    public interface IDataService
    {
        IEnumerable<Recipient> GetEmailRecipients();

        IEnumerable<Sender> GetSenders();

        bool UpdateRecipient(Recipient recipient);

        bool CreateRecipient(Recipient recipient);
    }
}
