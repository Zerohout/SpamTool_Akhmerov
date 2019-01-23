using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using SpamTool_Akhmerov.lib.Data;
using SpamTool_Akhmerov.lib.Service;

namespace SpamTool_Akhmerov.ViewModel
{
    public partial class MainWindowViewModel
    {
        /// <summary>
        /// Обновление списка получателей
        /// </summary>
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

        /// <summary>
        /// Создание нового получателя
        /// </summary>
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

        /// <summary>
        /// Изменение выбранного получателя
        /// </summary>
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

        /// <summary>
        /// Обновление списка отправителей
        /// </summary>
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

        /// <summary>
        /// Обновление списка серверов
        /// </summary>
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

        /// <summary>
        /// Обновление всех списков
        /// </summary>
        public ICommand UpdateAllDataCommand { get; }

        private bool CanUpdateAllDataCommandExecute() => true;

        private void OnUpdateAllDataCommandExecuted()
        {
            OnUpdateRecipientsCommandExecuted();
            OnUpdateSendersCommandExecuted();
            OnUpdateServersCommandExecuted();
        }

        /// <summary>
        /// Переход на следующую вкладку
        /// </summary>
        public ICommand GoToNextTabCommand { get; }

        private bool CanGoToNextTabCommandExecute() => true;

        private void OnGoToNextTabCommandExecuted()
        {
            if (CurrentTab < 3)
            {
                CurrentTab++;
            }
        }

        /// <summary>
        /// Переход на предыдущую вкладку
        /// </summary>
        public ICommand GoToPrevTabCommand { get; }

        private bool CanGoToPrevTabCommandExecute() => true;

        private void OnGoToPrevTabCommandExecuted()
        {
            if (CurrentTab > 0)
            {
                CurrentTab--;
            }
        }

        /// <summary>
        /// Выход из программы
        /// </summary>
        public ICommand ExitCommand { get; }

        private bool CanExitCommandExecute() => true;

        private void OnExitCommandExecuted()
        {
            App.Current.Shutdown();
        }

        /// <summary>
        /// Указание пути сохранения отчета
        /// </summary>
        public ICommand BrowseReportDirectory { get; }

        private bool CanBrowseReportDirectoryExecute() => true;

        private void OnBrowseReportDirectoryExecuted()
        {
            var folderBrowser = new SaveFileDialog
            {
                CreatePrompt = true,
                OverwritePrompt = true,
                InitialDirectory = ReportPath,
                Filter = SelectedReportFormat == "Microsoft Word" 
                    ? "Microsoft Word (*.docx)|*.docx" 
                    : "Microsoft Excel (*.xlsx)|*.xlsx"
            };

            folderBrowser.ShowDialog();
            ReportPath = folderBrowser.FileName;
        }

        /// <summary>
        /// Создание отчета
        /// </summary>
        public ICommand CreateReport { get; }

        private bool CanCreateReportExecute() => true;

        private void OnCreateReportExecuted()
        {
            if (SelectedReportFormat == "Microsoft Word")
            {
                var createReportDocxService = new CreateReportDocxService();
                createReportDocxService.CreatePackage(ReportPath, Recipients);
            }
            else
            {
                var createReportXlsxService = new CreateReportXlsxService();
                createReportXlsxService.CreateDocument(ReportPath,Recipients);
            }
        }
    }
}
