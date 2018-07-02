namespace TeamResourceTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeIDArimaryKeyForProjectResource : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProjectResources");
            AddPrimaryKey("dbo.ProjectResources", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProjectResources");
            AddPrimaryKey("dbo.ProjectResources", new[] { "ID", "ProjectID", "ResourceID" });
        }
    }
}
