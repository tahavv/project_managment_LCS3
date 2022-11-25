namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relatonships2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.employees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        Gender = c.String(),
                        DateOfBirthTime = c.DateTime(nullable: false),
                        hireDate = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.employees", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.employees", new[] { "User_Id" });
            DropTable("dbo.employees");
        }
    }
}
