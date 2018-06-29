namespace TeamResourceTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreFieldToProjectResources : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectResources", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectResources", "Note");
        }
    }
}
