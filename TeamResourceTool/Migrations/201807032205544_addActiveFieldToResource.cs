namespace TeamResourceTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addActiveFieldToResource : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resources", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resources", "IsActive");
        }
    }
}
