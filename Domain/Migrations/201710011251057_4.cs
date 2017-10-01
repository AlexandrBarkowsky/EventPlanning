namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventValues", "AttrName", c => c.String(nullable: false));
            AddColumn("dbo.EventValues", "AttrValue", c => c.String(nullable: false));
            DropColumn("dbo.EventValues", "GridName");
            DropColumn("dbo.EventValues", "GridValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventValues", "GridValue", c => c.String(nullable: false));
            AddColumn("dbo.EventValues", "GridName", c => c.String(nullable: false));
            DropColumn("dbo.EventValues", "AttrValue");
            DropColumn("dbo.EventValues", "AttrName");
        }
    }
}
