using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpamTool_Akhmerov.lib.Database;
using SpamTool_Akhmerov.lib.Interfaces;

namespace SpamTool_Akhmerov.lib.Service
{
    public class DataServiceDB : IDataService
    {
        private readonly SpamToolDatabaseDataContext dataBaseContext;

        public DataServiceDB(SpamToolDatabaseDataContext context) => dataBaseContext = context;

        public IEnumerable<EmailRecipients> GetEmailRecipients() => 
            new ObservableCollection<EmailRecipients>(dataBaseContext.EmailRecipients);

        public bool UpdateRecipient(EmailRecipients recipient)
        {
            dataBaseContext.SubmitChanges();
            return true;
        }

        public bool CreateRecipient(EmailRecipients recipient)
        {
            dataBaseContext.EmailRecipients.InsertOnSubmit(recipient);
            dataBaseContext.SubmitChanges();
            return recipient.Id != 0;
        }
    }
}
