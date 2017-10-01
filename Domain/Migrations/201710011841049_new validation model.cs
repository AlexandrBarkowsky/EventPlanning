namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newvalidationmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegisterOnEvents", "Email", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegisterOnEvents", "Email", c => c.String(nullable: false));
        }
    }
}
