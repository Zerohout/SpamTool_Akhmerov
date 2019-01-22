using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SpamTool_Akhmerov.lib.Data;
using SpamTool_Akhmerov.lib.Database;
using SpamTool_Akhmerov.lib.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SpamTool_Akhmerov.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDataService dataService;
        private readonly Scheduler _Scheduler = new Scheduler();

        public Scheduler Scheduler => _Scheduler;

        #region Свойства

        private int selectedTab = 0;

        public int SelectedTab
        {
            get => selectedTab;
            set => Set(ref selectedTab, value);
        }

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

        private EmailRecipient _currentRecipient;

        public EmailRecipient CurrentRecipient
        {
            get => _currentRecipient;
            set => Set(ref _currentRecipient, value);
        }

        private Sender _currentSender;

        public Sender CurrentSender
        {
            get => _currentSender;
            set => Set(ref _currentSender, value);
        }

        public ObservableCollection<EmailRecipient> Recipients { get; } = new ObservableCollection<EmailRecipient>();

        public ObservableCollection<Sender> Senders { get; } = new ObservableCollection<Sender>();

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
            var recipient = new EmailRecipient { Name = "Получатель", EmailAddress = "user@server.ru" };
            if (dataService.CreateRecipient(recipient))
            {
                CurrentRecipient = recipient;
                Recipients.Add(recipient);
            }
        }

        public ICommand UpdateRecipientCommand { get; }

        private bool CanUpdateRecipientCommandExecute(EmailRecipient recipient)
        {
            return true;
            //return recipient != null || CurrentRecipient != null;
        }

        private void OnUpdateRecipientCommandExecuted(EmailRecipient recipient)
        {
            var temp = recipient ?? _currentRecipient;
            if (temp is null) return;
            dataService.UpdateRecipient(temp);
        }

        public ICommand UpdateSendersCommand { get; }

        private bool CanUpdateSendersCommandExecute() => true;

        private void OnUpdateSendersCommandExecuted()
        {
            Senders.Clear();
            var dbSenders = dataService.GetSenders();
            foreach (var sender in dbSenders)
            {
                Senders.Add(sender);
            }
        }

        public ICommand GoToNextTabCommand { get; }

        private bool CanGoToNextTabCommandExecute()
        {
            return SelectedTab < 3;
        }

        private void OnGoToNextTabCommandExecuted()
        {
            SelectedTab++;
        }

        public ICommand GoToPrevTabCommand { get; }

        private bool CanGoToPrevTabCommandExecute()
        {
            return SelectedTab > 0;
        }
        
        private void OnGoToPrevTabCommandExecuted()
        {
            SelectedTab--;
        }

        public ICommand ExitCommand { get; }

        private bool CanExitCommandExecute() => true;

        private void OnExitCommandExecuted()
        {
            App.Current.Shutdown();
        }

        #endregion

        public MainWindowViewModel(IDataService dataService)
        {
            UpdateRecepientsCommand = new RelayCommand(OnUpdateRecipientsCommandExecuted, CanUpdateRecipientsCommandExecute);
            CreateNewRecipientCommand = new RelayCommand(OnCreateNewRecipientCommandExecuted);
            UpdateRecipientCommand = new RelayCommand<EmailRecipient>(OnUpdateRecipientCommandExecuted, CanUpdateRecipientCommandExecute);

            UpdateSendersCommand = new RelayCommand(OnUpdateSendersCommandExecuted, CanUpdateSendersCommandExecute);

            GoToNextTabCommand = new RelayCommand(OnGoToNextTabCommandExecuted, CanGoToNextTabCommandExecute);
            GoToPrevTabCommand = new RelayCommand(OnGoToPrevTabCommandExecuted, CanGoToPrevTabCommandExecute);

            ExitCommand = new RelayCommand(OnExitCommandExecuted, CanExitCommandExecute);
            
            this.dataService = dataService;
        }
    }
}
