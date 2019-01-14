using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Threading;
using SpamTool_Akhmerov.lib.Database;

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

        public void Send(string Subject, string Body, IEnumerable<EmailRecipient> recipients)
        {
            foreach (var email_recipient in recipients)
            {
                Send(Subject, Body, email_recipient.EmailAddress);
            }
        }

        public void SendParallel_Thread(string Subject, string Body, IEnumerable<EmailRecipient> recipients)
        {
            foreach (var email_recipient in recipients)
            {
                var sending_thread = new Thread(() => Send(Subject, Body, email_recipient.EmailAddress));
                sending_thread.Priority = ThreadPriority.BelowNormal;
                sending_thread.IsBackground = true;
                sending_thread.Start();
            }
        }

        public void SendParallel(string Subject, string Body, IEnumerable<EmailRecipient> recipients)
        {
            foreach (var address in recipients.Select(r => r.EmailAddress))
            {
                ThreadPool.QueueUserWorkItem(p => Send(Subject, Body, address));
            }
        }
    }
}
