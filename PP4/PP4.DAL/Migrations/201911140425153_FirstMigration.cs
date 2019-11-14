namespace PP4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        ID_Seat = c.Int(nullable: false, identity: true),
                        ID_Room = c.Int(nullable: false),
                        Row = c.String(),
                        Number = c.Int(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Seat)
                .ForeignKey("dbo.Rooms", t => t.ID_Room, cascadeDelete: true)
                .Index(t => t.ID_Room);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        ID_Purchase = c.Int(nullable: false),
                        ID_Person = c.Int(nullable: false),
                        ID_Schedule = c.Int(nullable: false),
                        ID_Seat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID_Purchase, t.ID_Person, t.ID_Schedule, t.ID_Seat })
                .ForeignKey("dbo.People", t => t.ID_Person, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.ID_Schedule, cascadeDelete: true)
                .ForeignKey("dbo.Seats", t => t.ID_Seat, cascadeDelete: true)
                .Index(t => t.ID_Person)
                .Index(t => t.ID_Schedule)
                .Index(t => t.ID_Seat);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID_Person = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Identification = c.String(),
                        Mail = c.String(),
                        Password = c.String(),
                        Ind_User = c.Boolean(nullable: false),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Person);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ID_Schedule = c.Int(nullable: false, identity: true),
                        ID_Movie = c.Int(nullable: false),
                        ID_Room = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Hour = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Schedule);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID_Movie = c.Int(nullable: false),
                        Tittle = c.String(),
                        Duration = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID_Movie)
                .ForeignKey("dbo.Schedules", t => t.ID_Movie)
                .Index(t => t.ID_Movie);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        ID_Room = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Room)
                .ForeignKey("dbo.Schedules", t => t.ID_Room)
                .Index(t => t.ID_Room);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "ID_Seat", "dbo.Seats");
            DropForeignKey("dbo.Seats", "ID_Room", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "ID_Room", "dbo.Schedules");
            DropForeignKey("dbo.Purchases", "ID_Schedule", "dbo.Schedules");
            DropForeignKey("dbo.Movies", "ID_Movie", "dbo.Schedules");
            DropForeignKey("dbo.Purchases", "ID_Person", "dbo.People");
            DropIndex("dbo.Rooms", new[] { "ID_Room" });
            DropIndex("dbo.Movies", new[] { "ID_Movie" });
            DropIndex("dbo.Purchases", new[] { "ID_Seat" });
            DropIndex("dbo.Purchases", new[] { "ID_Schedule" });
            DropIndex("dbo.Purchases", new[] { "ID_Person" });
            DropIndex("dbo.Seats", new[] { "ID_Room" });
            DropTable("dbo.Rooms");
            DropTable("dbo.Movies");
            DropTable("dbo.Schedules");
            DropTable("dbo.People");
            DropTable("dbo.Purchases");
            DropTable("dbo.Seats");
        }
    }
}
