using SpamTool_Akhmerov.lib.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Threading.Tasks;

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

        public void Send(string Subject, string Body, string Address)
        {
            using (var message = new MailMessage(UserName, Address))
            {
                message.Subject = Subject;
                message.Body = Body;

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

        public async Task SendAsync(string Subject, string Body, string Address)
        {
            using (var message = new MailMessage(UserName, Address))
            {
                message.Subject = Subject;
                message.Body = Body;

                using (var client = new SmtpClient(ServerAddress, Port))
                {
                    client.EnableSsl = UseSSL;
                    client.Credentials = new NetworkCredential(UserName, Password);

                    try
                    {
                        //client.Send(message);
                        await client.SendMailAsync(message).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        Trace.TraceError(e.Message);
                        Trace.TraceError(e.ToString());
                    }
                }
            }
        }

        public async Task SendAsync(string Subject, string Body, IEnumerable<Recipient> recipients)
        {
            foreach (var email_recipient in recipients)
                await SendAsync(Subject, Body, email_recipient.Address).ConfigureAwait(false);
        }

        public async Task SendParallelAsync(string Subject, string Body, IEnumerable<Recipient> recipients)
        {
            await Task.WhenAll(recipients.Select(recipient => SendAsync(Subject, Body, recipient.Address)))
                .ConfigureAwait(false);
        }
    }
}
