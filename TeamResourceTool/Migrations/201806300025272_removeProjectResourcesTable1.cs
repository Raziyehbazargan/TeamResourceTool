namespace TeamResourceTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeProjectResourcesTable1 : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.ProjectResources",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ProjectID = c.Int(nullable: false),
                    ResourceID = c.Int(nullable: false),
                    OnSite = c.Boolean(nullable: true),
                    Note = c.String(nullable: true)
                })
                .PrimaryKey(t => new { t.Id })
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.Resources", t => t.ResourceID, cascadeDelete: true)
                .Index(t => t.ProjectID)
                .Index(t => t.ResourceID);
        }

        public override void Down()
        {
            DropTable("dbo.ProjectResources");
        }
    }
}
