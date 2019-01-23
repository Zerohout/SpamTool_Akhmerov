using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpamTool_Akhmerov.lib.Data;

namespace SpamTool_Akhmerov.ViewModel
{
    public partial class MainWindowViewModel
    {

        
        private int _currentTab;
        /// <summary>
        /// Текущая вкладка
        /// </summary>
        public int CurrentTab
        {
            get => _currentTab;
            set => Set(ref _currentTab, value);
        }

        private string title = "Мастер-Спамстер";
        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title
        {
            get => title;
            set => Set(ref title, value);
        }

        private string status = "Готов";
        /// <summary>
        /// Статус программы
        /// </summary>
        public string Status
        {
            get => status;
            set => Set(ref status, value);
        }

        private Recipient _currentRecipient;
        /// <summary>
        /// Выбранный получатель
        /// </summary>
        public Recipient CurrentRecipient
        {
            get => _currentRecipient;
            set => Set(ref _currentRecipient, value);
        }

        private Sender _currentSender;
        /// <summary>
        /// Выбранный отправитель
        /// </summary>
        public Sender CurrentSender
        {
            get => _currentSender;
            set => Set(ref _currentSender, value);
        }

        private MailServer _currentServer;
        /// <summary>
        /// Выбранный сервер
        /// </summary>
        public MailServer CurrentServer
        {
            get => _currentServer;
            set => Set(ref _currentServer, value);
        }

        private string _reportPath
            = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.Parent?.FullName;
        /// <summary>
        /// Путь сохранения отчета
        /// </summary>
        public string ReportPath
        {
            get => _reportPath;
            set => Set(ref _reportPath, value);
        }

        private ObservableCollection<string> _reportFormats
            = new ObservableCollection<string>
            {
                "Microsoft Word",
                "Microsoft Excel"
            };
        /// <summary>
        /// Список форматов сохранения отчета
        /// </summary>
        public ObservableCollection<string> ReportFormats
        {
            get => _reportFormats;
            set => Set(ref _reportFormats, value);
        }

        private string _selectedReportFormat;
        /// <summary>
        /// Выбранный формат сохранения отчета
        /// </summary>
        public string SelectedReportFormat
        {
            get => _selectedReportFormat;
            set => Set(ref _selectedReportFormat, value);
        }
    }
}
