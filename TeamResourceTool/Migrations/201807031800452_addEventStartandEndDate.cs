namespace TeamResourceTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEventStartandEndDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "EventStartDate", c => c.DateTime());
            AddColumn("dbo.Projects", "EventEndDate", c => c.DateTime());
            DropColumn("dbo.Projects", "EventDates");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "EventDates", c => c.String());
            DropColumn("dbo.Projects", "EventEndDate");
            DropColumn("dbo.Projects", "EventStartDate");
        }
    }
}
