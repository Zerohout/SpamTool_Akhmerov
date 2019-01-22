using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SpamTool_Akhmerov.lib.Data;
using SpamTool_Akhmerov.lib.Interfaces;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Input;

namespace SpamTool_Akhmerov.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDataService dataService;

        private readonly Scheduler _Scheduler = new Scheduler();

        public Scheduler Scheduler => _Scheduler;

        #region Свойства

        private int _currentTab;

        public int CurrentTab
        {
            get => _currentTab;
            set => Set(ref _currentTab, value);
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

        private Recipient _currentRecipient;

        public Recipient CurrentRecipient
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

        private MailServer _currentServer;

        public MailServer CurrentServer
        {
            get => _currentServer;
            set => Set(ref _currentServer, value);
        }

        public ObservableCollection<Recipient> Recipients { get; } = new ObservableCollection<Recipient>();

        public ObservableCollection<Sender> Senders { get; } = new ObservableCollection<Sender>();

        public ObservableCollection<MailServer> Servers { get; } = new ObservableCollection<MailServer>();

        #endregion

        #region Команды

        public ICommand UpdateRecepientsCommand { get; }

        private bool CanUpdateRecipientsCommandExecute() => true;

        private void OnUpdateRecipientsCommandExecuted()
        {
            Recipients.Clear();

            using (var db = new DatabaseContext())
            {
                foreach (var recipient in db.Recipients)
                {
                    Recipients.Add(recipient);
                }
            }
        }

        public ICommand CreateNewRecipientCommand { get; }

        private void OnCreateNewRecipientCommandExecuted()
        {
            var number = Recipients.LastOrDefault()?.Id + 1;
            using (var db = new DatabaseContext())
            {
                db.Recipients.AddOrUpdate(new Recipient
                {
                    Name = $"Получатель{number}",
                    Address = $"user{number}@server.ru"
                });
                db.SaveChanges();
            }
        }

        public ICommand UpdateRecipientCommand { get; }

        private bool CanUpdateRecipientCommandExecute(Recipient recipient)
        {
            return true;
            //return recipient != null || CurrentRecipient != null;
        }

        private void OnUpdateRecipientCommandExecuted(Recipient recipient)
        {
            var temp = recipient ?? _currentRecipient;
            if (temp is null) return;

            using (var db = new DatabaseContext())
            {
                db.Recipients.AddOrUpdate(temp);

                db.SaveChanges();
            }
        }

        public ICommand UpdateSendersCommand { get; }

        private bool CanUpdateSendersCommandExecute() => true;

        private void OnUpdateSendersCommandExecuted()
        {
            Senders.Clear();

            using (var db = new DatabaseContext())
            {
                foreach (var sender in db.Senders)
                {
                    Senders.Add(sender);
                }
            }
        }

        public ICommand UpdateServersCommand { get; }

        private bool CanUpdateServersCommandExecute() => true;

        private void OnUpdateServersCommandExecuted()
        {
            Servers.Clear();

            using (var db = new DatabaseContext())
            {
                foreach (var server in db.Servers)
                {
                    Servers.Add(server);
                }
            }
        }

        public ICommand UpdateAllDataCommand { get; }

        private bool CanUpdateAllDataCommandExecute() => true;

        private void OnUpdateAllDataCommandExecuted()
        {
            OnUpdateRecipientsCommandExecuted();
            OnUpdateSendersCommandExecuted();
            OnUpdateServersCommandExecuted();
        }

        public ICommand GoToNextTabCommand { get; }

        private bool CanGoToNextTabCommandExecute() => true;

        private void OnGoToNextTabCommandExecuted()
        {
            if (CurrentTab < 3)
            {
                CurrentTab++;
            }
        }

        public ICommand GoToPrevTabCommand { get; }

        private bool CanGoToPrevTabCommandExecute() => true;

        private void OnGoToPrevTabCommandExecuted()
        {
            if (CurrentTab > 0)
            {
                CurrentTab--;
            }
        }

        public ICommand ExitCommand { get; }

        private bool CanExitCommandExecute() => true;

        private void OnExitCommandExecuted()
        {
            App.Current.Shutdown();
        }

        #endregion

        public MainWindowViewModel()
        {
            CreateNewRecipientCommand = new RelayCommand(OnCreateNewRecipientCommandExecuted);
            UpdateRecipientCommand = new RelayCommand<Recipient>(OnUpdateRecipientCommandExecuted, CanUpdateRecipientCommandExecute);

            UpdateRecepientsCommand = new RelayCommand(OnUpdateRecipientsCommandExecuted, CanUpdateRecipientsCommandExecute);
            UpdateSendersCommand = new RelayCommand(OnUpdateSendersCommandExecuted, CanUpdateSendersCommandExecute);
            UpdateServersCommand = new RelayCommand(OnUpdateServersCommandExecuted, CanUpdateServersCommandExecute);

            UpdateAllDataCommand = new RelayCommand(OnUpdateAllDataCommandExecuted, CanUpdateAllDataCommandExecute);

            GoToNextTabCommand = new RelayCommand(OnGoToNextTabCommandExecuted);
            GoToPrevTabCommand = new RelayCommand(OnGoToPrevTabCommandExecuted);

            ExitCommand = new RelayCommand(OnExitCommandExecuted, CanExitCommandExecute);


        }
    }
}
