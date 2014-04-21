namespace ConferenceData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendingDays : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SessionAttendees", "AttendingFirstDay", c => c.Boolean(nullable: false));
            AddColumn("dbo.SessionAttendees", "AttendingSecondDay", c => c.Boolean(nullable: false));
            AddColumn("dbo.SessionAttendees", "AttendingBothDays", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SessionAttendees", "AttendingBothDays");
            DropColumn("dbo.SessionAttendees", "AttendingSecondDay");
            DropColumn("dbo.SessionAttendees", "AttendingFirstDay");
        }
    }
}
