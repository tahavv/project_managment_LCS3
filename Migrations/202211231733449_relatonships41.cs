namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relatonships41 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tasks", "userId", c => c.String(maxLength: 128));
            CreateIndex("dbo.tasks", "userId");
            AddForeignKey("dbo.tasks", "userId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tasks", "userId", "dbo.AspNetUsers");
            DropIndex("dbo.tasks", new[] { "userId" });
            DropColumn("dbo.tasks", "userId");
        }
    }
}
