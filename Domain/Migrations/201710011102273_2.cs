namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Time = c.Time(nullable: false, precision: 7),
                        CountPeople = c.Int(nullable: false),
                        ReservedPeople = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GridName = c.String(nullable: false),
                        GridValue = c.String(nullable: false),
                        EventId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.RegisterOnEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Token = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegisterOnEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.EventValues", "EventId", "dbo.Events");
            DropIndex("dbo.RegisterOnEvents", new[] { "EventId" });
            DropIndex("dbo.EventValues", new[] { "EventId" });
            DropTable("dbo.RegisterOnEvents");
            DropTable("dbo.EventValues");
            DropTable("dbo.Events");
        }
    }
}
