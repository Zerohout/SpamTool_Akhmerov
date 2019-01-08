using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Policy;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SpamTool_Akhmerov.lib.Database;
using SpamTool_Akhmerov.lib.Interfaces;

namespace SpamTool_Akhmerov.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDataService dataService;

        #region Свойства

        private string title = "Мастер-Спамстер";

        public string Title
        {
            get => title;
            set => Set(ref title, value);
        }

        private string status = "Готов";

        public string Status
        {
            get => status;
            set => Set(ref status, value);
        }

        private EmailRecipients currentRecipient;

        public EmailRecipients CurrentRecipient
        {
            get => currentRecipient;
            set => Set(ref currentRecipient, value);
        }

        public ObservableCollection<EmailRecipients> Recipients { get; } = new ObservableCollection<EmailRecipients>();

        #endregion


        #region Команды

        public ICommand UpdateRecepientsCommand { get; }

        private bool CanUpdateRecipientsCommandExecute() => true;

        private void OnUpdateRecipientsCommandExecuted()
        {
            Recipients.Clear();
            var dbRecepients = dataService.GetEmailRecipients();
            foreach (var recipient in dbRecepients)
            {
                Recipients.Add(recipient);
            }
        }

        public ICommand CreateNewRecipientCommand { get; }

        private void OnCreateNewRecipientCommandExecuted()
        {
            var recipient = new EmailRecipients { Name = "Получатель", EmailAddress = "user@server.ru" };
            if (dataService.CreateRecipient(recipient))
            {
                CurrentRecipient = recipient;
                Recipients.Add(recipient);
            }
        }

        public ICommand UpdateRecipientCommand { get; }

        private bool CanUpdateRecipientCommandExecute(EmailRecipients recipient)
        {
            return true; /*recipient != null || currentRecipient != null;*/
        }

        private void OnUpdateRecipientCommandExecuted(EmailRecipients recipient)
        {
            var temp = recipient ?? currentRecipient;
            if (temp is null) return;
            dataService.UpdateRecipient(temp);
        }

        #endregion






        public MainWindowViewModel(IDataService dataService)
        {
            UpdateRecepientsCommand = new RelayCommand(OnUpdateRecipientsCommandExecuted, CanUpdateRecipientsCommandExecute);
            CreateNewRecipientCommand = new RelayCommand(OnCreateNewRecipientCommandExecuted);
            UpdateRecipientCommand = new RelayCommand<EmailRecipients>(OnUpdateRecipientCommandExecuted, CanUpdateRecipientCommandExecute);


            this.dataService = dataService;
        }
    }
}
