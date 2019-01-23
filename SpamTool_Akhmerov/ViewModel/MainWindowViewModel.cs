using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SpamTool_Akhmerov.lib.Data;
using SpamTool_Akhmerov.lib.Interfaces;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace SpamTool_Akhmerov.ViewModel
{
     public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly IDataService dataService;

        private readonly Scheduler _Scheduler = new Scheduler();

        public Scheduler Scheduler => _Scheduler;
        
        public ObservableCollection<Recipient> Recipients { get; } = new ObservableCollection<Recipient>();

        public ObservableCollection<Sender> Senders { get; } = new ObservableCollection<Sender>();

        public ObservableCollection<MailServer> Servers { get; } = new ObservableCollection<MailServer>();
        
        public MainWindowViewModel()
        {
            CreateNewRecipientCommand = new RelayCommand(OnCreateNewRecipientCommandExecuted);
            UpdateRecipientCommand = new RelayCommand<Recipient>(OnUpdateRecipientCommandExecuted, CanUpdateRecipientCommandExecute);

            UpdateRecepientsCommand = new RelayCommand(OnUpdateRecipientsCommandExecuted, CanUpdateRecipientsCommandExecute);
            UpdateSendersCommand = new RelayCommand(OnUpdateSendersCommandExecuted, CanUpdateSendersCommandExecute);
            UpdateServersCommand = new RelayCommand(OnUpdateServersCommandExecuted, CanUpdateServersCommandExecute);

            UpdateAllDataCommand = new RelayCommand(OnUpdateAllDataCommandExecuted, CanUpdateAllDataCommandExecute);

            BrowseReportDirectory = new RelayCommand(OnBrowseReportDirectoryExecuted, CanBrowseReportDirectoryExecute);
            CreateReport = new RelayCommand(OnCreateReportExecuted, CanCreateReportExecute);

            GoToNextTabCommand = new RelayCommand(OnGoToNextTabCommandExecuted);
            GoToPrevTabCommand = new RelayCommand(OnGoToPrevTabCommandExecuted);

            ExitCommand = new RelayCommand(OnExitCommandExecuted, CanExitCommandExecute);


        }
    }
}
