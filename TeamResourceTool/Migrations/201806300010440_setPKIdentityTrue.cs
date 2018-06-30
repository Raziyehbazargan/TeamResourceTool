namespace TeamResourceTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setPKIdentityTrue : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProjectResources", "Id");
            AddPrimaryKey("dbo.ProjectResources", "Id");
            AlterColumn("dbo.ProjectResources", "Id", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
        }
    }
}
