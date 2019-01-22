using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SpamTool_Akhmerov.lib.Data;
using SpamTool_Akhmerov.lib.Service;
using System.Security;
using System.Windows;

namespace SpamTool_Akhmerov
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            BtnPreviousTab.IsEnabled = false;
        }

        private async void OnSendButtonClick(object Sender, RoutedEventArgs e)
        {
            //var server = Servers.SelectedItem as MailServer;
            //if (server == null)
            //{
            //    MessageBox.Show("Сервер не выбран!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}

            //var server = CBoxSenders.SelectedItem as MailServer;
            //if (server == null)
            //{
            //    await this.ShowMessageAsync("Ошибка", "Сервер не выбран!");
            //    return;
            //}

            //var sender = CBoxSenders.SelectedItem as Sender;
            //if (sender == null)
            //{
            //    await this.ShowMessageAsync("Ошибка", "Отправитель не выбран!");
            //    return;
            //}

            //var password = new SecureString();
            //foreach (var password_char in PasswordService.Decode(sender.Password))
            //    password.AppendChar(password_char);


            //var send_mail_service = new MailSenderService(
            //    server.Address, server.Port, server.UseSSL,
            //    sender.Address, password);

            //send_mail_service.Send("Subject", "Email body", "email@server.com");
        }

        private void OnBtnPreviousTabClick(object sender, RoutedEventArgs e)
        {
            if (!BtnNextTab.IsEnabled)
            {
                BtnNextTab.IsEnabled = true;
            }
            TabControlSpamTool.SelectedIndex--;

            if (TabControlSpamTool.SelectedIndex == 0)
            {
                BtnPreviousTab.IsEnabled = false;
            }
        }

        private void OnBtnNextTabClick(object sender, RoutedEventArgs e)
        {
            if (!BtnPreviousTab.IsEnabled)
            {
                BtnPreviousTab.IsEnabled = true;
            }
            TabControlSpamTool.SelectedIndex++;

            if (TabControlSpamTool.SelectedIndex == TabControlSpamTool.Items.Count - 1)
            {
                BtnNextTab.IsEnabled = false;
            }
        }

        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TabControlSpamTool_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (TabControlSpamTool.SelectedIndex == 0)
            {
                BtnPreviousTab.IsEnabled = false;
            }

            if (TabControlSpamTool.SelectedIndex == TabControlSpamTool.Items.Count - 1)
            {
                BtnNextTab.IsEnabled = false;
            }

            if (BtnNextTab != null && !BtnNextTab.IsEnabled &&
                TabControlSpamTool.SelectedIndex != TabControlSpamTool.Items.Count - 1)
            {
                BtnNextTab.IsEnabled = true;
            }

            if (BtnPreviousTab != null && !BtnPreviousTab.IsEnabled && TabControlSpamTool.SelectedIndex != 0)
            {
                BtnPreviousTab.IsEnabled = true;
            }
        }
    }
}
