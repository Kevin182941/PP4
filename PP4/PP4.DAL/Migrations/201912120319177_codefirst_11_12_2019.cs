namespace PP4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class codefirst_11_12_2019 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        ID_Batch = c.Int(nullable: false, identity: true),
                        ID_Room = c.Int(nullable: false),
                        ID_Schedule = c.Int(nullable: false),
                        ID_Movie = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Batch)
                .ForeignKey("dbo.Movies", t => t.ID_Movie, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.ID_Room, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.ID_Schedule, cascadeDelete: true)
                .Index(t => t.ID_Room)
                .Index(t => t.ID_Schedule)
                .Index(t => t.ID_Movie);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        ID_Purchase = c.Int(nullable: false, identity: true),
                        ID_Batch = c.Int(nullable: false),
                        ID_Person = c.Int(nullable: false),
                        Date_Purchase = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Purchase)
                .ForeignKey("dbo.Batches", t => t.ID_Batch, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.ID_Person, cascadeDelete: true)
                .Index(t => t.ID_Batch)
                .Index(t => t.ID_Person);
            
            CreateTable(
                "dbo.Purchase_Seat",
                c => new
                    {
                        ID_Purchase_Seat = c.Int(nullable: false, identity: true),
                        ID_Purchase = c.Int(nullable: false),
                        ID_Seat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Purchase_Seat)
                .ForeignKey("dbo.Purchases", t => t.ID_Purchase, cascadeDelete: true)
                .ForeignKey("dbo.Seats", t => t.ID_Seat, cascadeDelete: false)
                .Index(t => t.ID_Purchase)
                .Index(t => t.ID_Seat);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID_Movie = c.Int(nullable: false, identity: true),
                        Description_Movie = c.String(),
                        Duration = c.Int(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Movie);
            
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
                "dbo.Rooms",
                c => new
                    {
                        ID_Room = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Capacity = c.Int(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Room);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        ID_Seat = c.Int(nullable: false, identity: true),
                        ID_Room = c.Int(nullable: false),
                        Description_Seat = c.String(),
                        Row = c.String(),
                        Number = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID_Seat)
                .ForeignKey("dbo.Rooms", t => t.ID_Room, cascadeDelete: true)
                .Index(t => t.ID_Room);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ID_Schedule = c.Int(nullable: false, identity: true),
                        Day = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Schedule);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Batches", "ID_Schedule", "dbo.Schedules");
            DropForeignKey("dbo.Seats", "ID_Room", "dbo.Rooms");
            DropForeignKey("dbo.Purchase_Seat", "ID_Seat", "dbo.Seats");
            DropForeignKey("dbo.Batches", "ID_Room", "dbo.Rooms");
            DropForeignKey("dbo.Purchases", "ID_Person", "dbo.People");
            DropForeignKey("dbo.Batches", "ID_Movie", "dbo.Movies");
            DropForeignKey("dbo.Purchases", "ID_Batch", "dbo.Batches");
            DropForeignKey("dbo.Purchase_Seat", "ID_Purchase", "dbo.Purchases");
            DropIndex("dbo.Seats", new[] { "ID_Room" });
            DropIndex("dbo.Purchase_Seat", new[] { "ID_Seat" });
            DropIndex("dbo.Purchase_Seat", new[] { "ID_Purchase" });
            DropIndex("dbo.Purchases", new[] { "ID_Person" });
            DropIndex("dbo.Purchases", new[] { "ID_Batch" });
            DropIndex("dbo.Batches", new[] { "ID_Movie" });
            DropIndex("dbo.Batches", new[] { "ID_Schedule" });
            DropIndex("dbo.Batches", new[] { "ID_Room" });
            DropTable("dbo.Schedules");
            DropTable("dbo.Seats");
            DropTable("dbo.Rooms");
            DropTable("dbo.People");
            DropTable("dbo.Movies");
            DropTable("dbo.Purchase_Seat");
            DropTable("dbo.Purchases");
            DropTable("dbo.Batches");
        }
    }
}
