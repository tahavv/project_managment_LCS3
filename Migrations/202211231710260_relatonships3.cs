namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relatonships3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "DateOfBirthTime", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "hireDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "hireDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "DateOfBirthTime", c => c.DateTime(nullable: false));
        }
    }
}
