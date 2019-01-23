using System.Collections.Generic;
using SpamTool_Akhmerov.lib.Data;

namespace SpamTool_Akhmerov.lib.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DatabaseContext context)
        {
            //context.Recipients.AddOrUpdate( r => r.Name,
            //    new Recipient { Name = "FirstRecipient", Address = "first_recipient@mail.ru" },
            //    new Recipient { Name = "SecondRecipient", Address = "second_recipient@mail.ru" },
            //    new Recipient { Name = "ThirdRecipient", Address = "third_recipient@mail.ru" });

            //context.Servers.AddOrUpdate(sr => sr.Address,
            //    new MailServer{Address = "smtp.yandex.ru"},
            //    new MailServer{Address = "smtp.mail.ru" },
            //    new MailServer{Address = "smtp.google.com", Port = 455}
            //);

            //context.SaveChanges();

            //context.Mails.AddOrUpdate(m => m.Body,
            //    new Mail
            //    {
            //        Body = "FirstBody",
            //        Subject = "FirstSubject",
            //        MailServer = context.Servers.Local.FirstOrDefault(),
            //        Recipients = context.Recipients.Local
            //    },
            //    new Mail
            //    {
            //        Body = "SecondBody",
            //        Subject = "SecondSubject",
            //        MailServer = context.Servers.Local.FirstOrDefault(),
            //        Recipients = context.Recipients.Local
            //    },
            //    new Mail
            //    {
            //        Body = "ThirdBody",
            //        Subject = "ThirdSubject",
            //        MailServer = context.Servers.Local.FirstOrDefault(),
            //        Recipients = context.Recipients.Local
            //    });

            //context.SaveChanges();

            //context.Senders.AddOrUpdate(sn => sn.Login,
            //    new Sender
            //    {
            //        Name = "FirstSender",
            //        Email = "first@yandex.ru",
            //        Login = "first@yandex.ru",
            //        Password = "P@ssW0rd",
            //        Recipients = context.Recipients.Local,
            //        Mails = context.Mails.Local
            //    });

            //context.SaveChanges();

            //context.SchedulerTasks.AddOrUpdate(st => st.Name,
            //    new SchedulerTask
            //    {
            //        Name = "FirstTask",
            //        Description = "TestTask",
            //        Mail = context.Mails.Local.FirstOrDefault(),
            //        Recipients = context.Recipients.Local,
            //        Sender = context.Senders.Local.FirstOrDefault(),
            //        Server = context.Servers.Local.FirstOrDefault(),
            //        Time = DateTime.Now.Add(TimeSpan.FromMinutes(30))
            //    });

            //context.SaveChanges();
        }
    }
}
