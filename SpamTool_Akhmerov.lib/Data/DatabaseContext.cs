using System.Data.Entity;

namespace SpamTool_Akhmerov.lib.Data
{
    public class DatabaseContext : DbContext
    {
        static DatabaseContext()
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Migrations.Configuration>(true));
        }

        public DbSet<Mail> Mails { get; set; }
        public DbSet<MailServer> Servers { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Sender> Senders { get; set; }
        public DbSet<SchedulerTask> SchedulerTasks { get; set; }

        public DatabaseContext() : this("name=SpamDatabase") { }

        public DatabaseContext(string ConnectionString)
            : base(ConnectionString)
        {

        }
    }
}
