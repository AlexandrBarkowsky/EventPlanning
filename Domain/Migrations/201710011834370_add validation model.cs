namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvalidationmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegisterOnEvents", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.RegisterOnEvents", "LastName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegisterOnEvents", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.RegisterOnEvents", "FirstName", c => c.String(nullable: false));
        }
    }
}
