namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relatonships : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tasks", "projectId", c => c.Int(nullable: false));
            CreateIndex("dbo.tasks", "projectId");
            AddForeignKey("dbo.tasks", "projectId", "dbo.projects", "projectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tasks", "projectId", "dbo.projects");
            DropIndex("dbo.tasks", new[] { "projectId" });
            DropColumn("dbo.tasks", "projectId");
        }
    }
}
