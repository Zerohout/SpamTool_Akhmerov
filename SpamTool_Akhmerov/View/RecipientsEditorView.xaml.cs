using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpamTool_Akhmerov.View
{
    /// <summary>
    /// Логика взаимодействия для RecipientsEditorView.xaml
    /// </summary>
    public partial class RecipientsEditorView : UserControl
    {
        public RecipientsEditorView()
        {
            InitializeComponent();
        }

        private void OnValidationError(object Sender, ValidationErrorEventArgs E)
        {
            var event_sender = (Control)Sender;
            if (E.Action == ValidationErrorEventAction.Added)
            {
                event_sender.ToolTip = E.Error.ErrorContent.ToString();
            }
            else
            {
                event_sender.ToolTip = "";
            }
        }
    }
}
