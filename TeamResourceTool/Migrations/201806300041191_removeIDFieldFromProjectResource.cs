namespace TeamResourceTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeIDFieldFromProjectResource : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjectResources", "Id", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectResources", "Id", c => c.Int(nullable: false));
        }
    }
}
