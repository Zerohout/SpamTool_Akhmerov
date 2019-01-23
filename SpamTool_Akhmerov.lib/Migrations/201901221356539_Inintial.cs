namespace SpamTool_Akhmerov.lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inintial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Body = c.String(),
                        MailServer_Id = c.Int(),
                        Sender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MailServers", t => t.MailServer_Id)
                .ForeignKey("dbo.Senders", t => t.Sender_Id)
                .Index(t => t.MailServer_Id)
                .Index(t => t.Sender_Id);
            
            CreateTable(
                "dbo.MailServers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Port = c.Int(nullable: false),
                        UseSSL = c.Boolean(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        SenderId = c.Int(nullable: false),
                        MailId = c.Int(nullable: false),
                        ScheluderTaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mails", t => t.MailId, cascadeDelete: true)
                .ForeignKey("dbo.Senders", t => t.SenderId, cascadeDelete: true)
                .Index(t => t.SenderId)
                .Index(t => t.MailId);
            
            CreateTable(
                "dbo.Senders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SchedulerTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Mail_Id = c.Int(),
                        Sender_Id = c.Int(),
                        Server_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mails", t => t.Mail_Id)
                .ForeignKey("dbo.Senders", t => t.Sender_Id)
                .ForeignKey("dbo.MailServers", t => t.Server_Id)
                .Index(t => t.Mail_Id)
                .Index(t => t.Sender_Id)
                .Index(t => t.Server_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchedulerTasks", "Server_Id", "dbo.MailServers");
            DropForeignKey("dbo.SchedulerTasks", "Sender_Id", "dbo.Senders");
            DropForeignKey("dbo.SchedulerTasks", "Mail_Id", "dbo.Mails");
            DropForeignKey("dbo.Recipients", "SenderId", "dbo.Senders");
            DropForeignKey("dbo.Mails", "Sender_Id", "dbo.Senders");
            DropForeignKey("dbo.Recipients", "MailId", "dbo.Mails");
            DropForeignKey("dbo.Mails", "MailServer_Id", "dbo.MailServers");
            DropIndex("dbo.SchedulerTasks", new[] { "Server_Id" });
            DropIndex("dbo.SchedulerTasks", new[] { "Sender_Id" });
            DropIndex("dbo.SchedulerTasks", new[] { "Mail_Id" });
            DropIndex("dbo.Recipients", new[] { "MailId" });
            DropIndex("dbo.Recipients", new[] { "SenderId" });
            DropIndex("dbo.Mails", new[] { "Sender_Id" });
            DropIndex("dbo.Mails", new[] { "MailServer_Id" });
            DropTable("dbo.SchedulerTasks");
            DropTable("dbo.Senders");
            DropTable("dbo.Recipients");
            DropTable("dbo.MailServers");
            DropTable("dbo.Mails");
        }
    }
}
