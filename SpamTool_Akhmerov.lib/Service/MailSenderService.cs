using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Security;

namespace SpamTool_Akhmerov.lib.Service
{
    public class MailSenderService
    {
        private string ServerAddress;
        private int Port;
        private bool UseSSL;
        private string UserName;
        private SecureString Password;

        public MailSenderService(string ServerAddress, int Port, bool UseSSL, string UserName, SecureString Password)
        {
            this.ServerAddress = ServerAddress;
            this.Port = Port;
            this.UseSSL = UseSSL;
            this.UserName = UserName;
            this.Password = Password;
        }

        public void Send(string Subject, string Email, string Address)
        {
            using (var message = new MailMessage(UserName, Address))
            {
                message.Subject = Subject;
                message.Body = Email;

                using (var client = new SmtpClient(ServerAddress, Port))
                {
                    client.EnableSsl = UseSSL;
                    client.Credentials = new NetworkCredential(UserName, Password);

                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception e)
                    {
                        Trace.TraceError(e.Message);
                        Trace.TraceError(e.ToString());
                    }
                }
            }
        }
    }
}
