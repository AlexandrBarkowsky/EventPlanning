namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvalidationstring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Name", c => c.String(nullable: false));
        }
    }
}
