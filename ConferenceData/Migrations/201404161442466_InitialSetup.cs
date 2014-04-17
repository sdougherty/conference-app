namespace ConferenceData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConferenceAttendees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationTime = c.DateTime(),
                        User_Id = c.Int(),
                        Conference_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Conferences", t => t.Conference_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Conference_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        JobTitle = c.String(),
                        Location = c.String(),
                        Team = c.String(),
                        Interests = c.String(),
                        Bio = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Conferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(),
                        FinishDate = c.DateTime(),
                        Location = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Location = c.String(),
                        Room = c.String(),
                        StartTime = c.DateTime(),
                        FinishTime = c.DateTime(),
                        Format_Id = c.Int(),
                        Conference_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SessionFormats", t => t.Format_Id)
                .ForeignKey("dbo.Conferences", t => t.Conference_Id)
                .Index(t => t.Format_Id)
                .Index(t => t.Conference_Id);
            
            CreateTable(
                "dbo.SessionAttendees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationTime = c.DateTime(),
                        Session_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.Session_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Session_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.SessionFormats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Conference_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conferences", t => t.Conference_Id)
                .Index(t => t.Conference_Id);
            
            CreateTable(
                "dbo.SessionSpeakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Session_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.Session_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Session_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Conference_Id = c.Int(),
                        Session_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conferences", t => t.Conference_Id)
                .ForeignKey("dbo.Sessions", t => t.Session_Id)
                .Index(t => t.Conference_Id)
                .Index(t => t.Session_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "Conference_Id", "dbo.Conferences");
            DropForeignKey("dbo.Tracks", "Session_Id", "dbo.Sessions");
            DropForeignKey("dbo.Tracks", "Conference_Id", "dbo.Conferences");
            DropForeignKey("dbo.SessionSpeakers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.SessionSpeakers", "Session_Id", "dbo.Sessions");
            DropForeignKey("dbo.Sessions", "Format_Id", "dbo.SessionFormats");
            DropForeignKey("dbo.SessionFormats", "Conference_Id", "dbo.Conferences");
            DropForeignKey("dbo.SessionAttendees", "User_Id", "dbo.Users");
            DropForeignKey("dbo.SessionAttendees", "Session_Id", "dbo.Sessions");
            DropForeignKey("dbo.ConferenceAttendees", "Conference_Id", "dbo.Conferences");
            DropForeignKey("dbo.ConferenceAttendees", "User_Id", "dbo.Users");
            DropIndex("dbo.Tracks", new[] { "Session_Id" });
            DropIndex("dbo.Tracks", new[] { "Conference_Id" });
            DropIndex("dbo.SessionSpeakers", new[] { "User_Id" });
            DropIndex("dbo.SessionSpeakers", new[] { "Session_Id" });
            DropIndex("dbo.SessionFormats", new[] { "Conference_Id" });
            DropIndex("dbo.SessionAttendees", new[] { "User_Id" });
            DropIndex("dbo.SessionAttendees", new[] { "Session_Id" });
            DropIndex("dbo.Sessions", new[] { "Conference_Id" });
            DropIndex("dbo.Sessions", new[] { "Format_Id" });
            DropIndex("dbo.ConferenceAttendees", new[] { "Conference_Id" });
            DropIndex("dbo.ConferenceAttendees", new[] { "User_Id" });
            DropTable("dbo.Tracks");
            DropTable("dbo.SessionSpeakers");
            DropTable("dbo.SessionFormats");
            DropTable("dbo.SessionAttendees");
            DropTable("dbo.Sessions");
            DropTable("dbo.Conferences");
            DropTable("dbo.Users");
            DropTable("dbo.ConferenceAttendees");
        }
    }
}
