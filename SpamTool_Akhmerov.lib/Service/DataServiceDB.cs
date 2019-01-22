using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpamTool_Akhmerov.lib.Data;
using SpamTool_Akhmerov.lib.Database;
using SpamTool_Akhmerov.lib.Interfaces;

namespace SpamTool_Akhmerov.lib.Service
{
    public class DataServiceDB : IDataService
    {
        private readonly SpamToolDatabaseDataContext dataBaseContext;

        public DataServiceDB(SpamToolDatabaseDataContext context) => dataBaseContext = context;

        #region Recipients
        
        public IEnumerable<EmailRecipient> GetEmailRecipients() => 
            new ObservableCollection<EmailRecipient>(dataBaseContext.EmailRecipient);
        
        public bool UpdateRecipient(EmailRecipient recipient)
        {
            dataBaseContext.SubmitChanges();
            return true;
        }

        public bool CreateRecipient(EmailRecipient recipient)
        {
            dataBaseContext.EmailRecipient.InsertOnSubmit(recipient);
            dataBaseContext.SubmitChanges();
            return recipient.Id != 0;
        }

        #endregion

        public IEnumerable<Sender> GetSenders() =>
            new ObservableCollection<Sender>(dataBaseContext.Sender);
        
    }
}
