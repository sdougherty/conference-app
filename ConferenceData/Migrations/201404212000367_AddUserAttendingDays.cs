namespace ConferenceData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAttendingDays : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "AttendingFirstDay", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "AttendingSecondDay", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "AttendingBothDays", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "AttendingBothDays");
            DropColumn("dbo.Users", "AttendingSecondDay");
            DropColumn("dbo.Users", "AttendingFirstDay");
        }
    }
}
