namespace ConferenceData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSessionLeadersAndCleanup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConferenceAttendees", "AttendingFirstDay", c => c.Boolean(nullable: false));
            AddColumn("dbo.ConferenceAttendees", "AttendingSecondDay", c => c.Boolean(nullable: false));
            AddColumn("dbo.ConferenceAttendees", "AttendingBothDays", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sessions", "Leaders", c => c.String());
            DropColumn("dbo.SessionAttendees", "AttendingFirstDay");
            DropColumn("dbo.SessionAttendees", "AttendingSecondDay");
            DropColumn("dbo.SessionAttendees", "AttendingBothDays");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SessionAttendees", "AttendingBothDays", c => c.Boolean(nullable: false));
            AddColumn("dbo.SessionAttendees", "AttendingSecondDay", c => c.Boolean(nullable: false));
            AddColumn("dbo.SessionAttendees", "AttendingFirstDay", c => c.Boolean(nullable: false));
            DropColumn("dbo.Sessions", "Leaders");
            DropColumn("dbo.ConferenceAttendees", "AttendingBothDays");
            DropColumn("dbo.ConferenceAttendees", "AttendingSecondDay");
            DropColumn("dbo.ConferenceAttendees", "AttendingFirstDay");
        }
    }
}
