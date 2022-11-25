namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relatonships4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.projects", "userId", c => c.String(maxLength: 128));
            CreateIndex("dbo.projects", "userId");
            AddForeignKey("dbo.projects", "userId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.projects", "userId", "dbo.AspNetUsers");
            DropIndex("dbo.projects", new[] { "userId" });
            DropColumn("dbo.projects", "userId");
        }
    }
}
