namespace PP4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiosCodeFirst27_11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "ID_Movie", "dbo.Schedule_Room_Movie");
            DropForeignKey("dbo.Rooms", "ID_Room", "dbo.Schedule_Room_Movie");
            DropForeignKey("dbo.Purchase_Seat", "ID_Purchase", "dbo.Purchases");
            DropForeignKey("dbo.Purchases", "ID_Schedule_Room_Movie", "dbo.Schedule_Room_Movie");
            DropForeignKey("dbo.Purchase_Seat", "ID_Seat", "dbo.Seats");
            DropForeignKey("dbo.Schedules", "ID_Schedule", "dbo.Schedule_Room_Movie");
            DropForeignKey("dbo.Seats", "ID_Room", "dbo.Rooms");
            DropIndex("dbo.Movies", new[] { "ID_Movie" });
            DropIndex("dbo.Rooms", new[] { "ID_Room" });
            DropIndex("dbo.Purchase_Seat", new[] { "ID_Purchase" });
            DropIndex("dbo.Purchase_Seat", new[] { "ID_Seat" });
            DropIndex("dbo.Purchases", new[] { "ID_Schedule_Room_Movie" });
            DropIndex("dbo.Schedules", new[] { "ID_Schedule" });
            DropPrimaryKey("dbo.Movies");
            DropPrimaryKey("dbo.Rooms");
            DropPrimaryKey("dbo.Purchase_Seat");
            DropPrimaryKey("dbo.Schedules");
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        ID_Batch = c.Int(nullable: false, identity: true),
                        ID_Room = c.Int(nullable: false),
                        ID_Schedule = c.Int(nullable: false),
                        ID_Movie = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Batch);
            
            AddColumn("dbo.Movies", "Description_Movie", c => c.String());
            AddColumn("dbo.Movies", "State", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rooms", "Description", c => c.String());
            AddColumn("dbo.Seats", "Description_Seat", c => c.String());
            DropColumn("dbo.Purchase_Seat", "ID_Deta");
            AddColumn("dbo.Purchase_Seat", "ID_Purchase_Seat", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Purchase_Seat", "Person_ID_Person", c => c.Int());
            AddColumn("dbo.Purchases", "ID_Batch", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "Date_Purchase", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedules", "State", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Movies", "ID_Movie", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Rooms", "ID_Room", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Schedules", "ID_Schedule", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Schedules", "Day", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Movies", "ID_Movie");
            AddPrimaryKey("dbo.Rooms", "ID_Room");
            AddPrimaryKey("dbo.Purchase_Seat", "ID_Purchase_Seat");
            AddPrimaryKey("dbo.Schedules", "ID_Schedule");
            CreateIndex("dbo.Movies", "ID_Movie");
            CreateIndex("dbo.Rooms", "ID_Room");
            CreateIndex("dbo.Seats", "ID_Seat");
            CreateIndex("dbo.Schedules", "ID_Schedule");
            CreateIndex("dbo.Purchases", "ID_Purchase");
            CreateIndex("dbo.Purchases", "ID_Batch");
            CreateIndex("dbo.Purchase_Seat", "Person_ID_Person");
            AddForeignKey("dbo.Movies", "ID_Movie", "dbo.Batches", "ID_Batch");
            AddForeignKey("dbo.Rooms", "ID_Room", "dbo.Batches", "ID_Batch");
            AddForeignKey("dbo.Schedules", "ID_Schedule", "dbo.Batches", "ID_Batch");
            AddForeignKey("dbo.Purchases", "ID_Batch", "dbo.Batches", "ID_Batch", cascadeDelete: true);
            AddForeignKey("dbo.Purchase_Seat", "Person_ID_Person", "dbo.People", "ID_Person");
            AddForeignKey("dbo.Purchases", "ID_Purchase", "dbo.Purchase_Seat", "ID_Purchase_Seat");
            AddForeignKey("dbo.Seats", "ID_Seat", "dbo.Purchase_Seat", "ID_Purchase_Seat");
            AddForeignKey("dbo.Seats", "ID_Room", "dbo.Rooms", "ID_Room", cascadeDelete: true);
            DropColumn("dbo.Movies", "Tittle");
            DropColumn("dbo.Purchases", "ID_Schedule_Room_Movie");
            DropColumn("dbo.Schedules", "ID_Schedule_Room_Movie");
            DropColumn("dbo.Schedules", "Hour");
            DropTable("dbo.Schedule_Room_Movie");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Schedule_Room_Movie",
                c => new
                    {
                        ID_Schedule_Room_Movie = c.Int(nullable: false, identity: true),
                        ID_Schedule = c.Int(nullable: false),
                        ID_Room = c.Int(nullable: false),
                        ID_Movie = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Schedule_Room_Movie);
            
            AddColumn("dbo.Schedules", "Hour", c => c.Int(nullable: false));
            AddColumn("dbo.Schedules", "ID_Schedule_Room_Movie", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "ID_Schedule_Room_Movie", c => c.Int(nullable: false));
            AddColumn("dbo.Purchase_Seat", "ID_Deta", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Movies", "Tittle", c => c.String());
            DropForeignKey("dbo.Seats", "ID_Room", "dbo.Rooms");
            DropForeignKey("dbo.Seats", "ID_Seat", "dbo.Purchase_Seat");
            DropForeignKey("dbo.Purchases", "ID_Purchase", "dbo.Purchase_Seat");
            DropForeignKey("dbo.Purchase_Seat", "Person_ID_Person", "dbo.People");
            DropForeignKey("dbo.Purchases", "ID_Batch", "dbo.Batches");
            DropForeignKey("dbo.Schedules", "ID_Schedule", "dbo.Batches");
            DropForeignKey("dbo.Rooms", "ID_Room", "dbo.Batches");
            DropForeignKey("dbo.Movies", "ID_Movie", "dbo.Batches");
            DropIndex("dbo.Purchase_Seat", new[] { "Person_ID_Person" });
            DropIndex("dbo.Purchases", new[] { "ID_Batch" });
            DropIndex("dbo.Purchases", new[] { "ID_Purchase" });
            DropIndex("dbo.Schedules", new[] { "ID_Schedule" });
            DropIndex("dbo.Seats", new[] { "ID_Seat" });
            DropIndex("dbo.Rooms", new[] { "ID_Room" });
            DropIndex("dbo.Movies", new[] { "ID_Movie" });
            DropPrimaryKey("dbo.Schedules");
            DropPrimaryKey("dbo.Purchase_Seat");
            DropPrimaryKey("dbo.Rooms");
            DropPrimaryKey("dbo.Movies");
            AlterColumn("dbo.Schedules", "Day", c => c.Int(nullable: false));
            AlterColumn("dbo.Schedules", "ID_Schedule", c => c.Int(nullable: false));
            AlterColumn("dbo.Rooms", "ID_Room", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "ID_Movie", c => c.Int(nullable: false));
            DropColumn("dbo.Schedules", "State");
            DropColumn("dbo.Purchases", "Date_Purchase");
            DropColumn("dbo.Purchases", "ID_Batch");
            DropColumn("dbo.Purchase_Seat", "Person_ID_Person");
            DropColumn("dbo.Purchase_Seat", "ID_Purchase_Seat");
            DropColumn("dbo.Seats", "Description_Seat");
            DropColumn("dbo.Rooms", "Description");
            DropColumn("dbo.Movies", "State");
            DropColumn("dbo.Movies", "Description_Movie");
            DropTable("dbo.Batches");
            AddPrimaryKey("dbo.Schedules", "ID_Schedule");
            AddPrimaryKey("dbo.Purchase_Seat", "ID_Deta");
            AddPrimaryKey("dbo.Rooms", "ID_Room");
            AddPrimaryKey("dbo.Movies", "ID_Movie");
            CreateIndex("dbo.Schedules", "ID_Schedule");
            CreateIndex("dbo.Purchases", "ID_Schedule_Room_Movie");
            CreateIndex("dbo.Purchase_Seat", "ID_Seat");
            CreateIndex("dbo.Purchase_Seat", "ID_Purchase");
            CreateIndex("dbo.Rooms", "ID_Room");
            CreateIndex("dbo.Movies", "ID_Movie");
            AddForeignKey("dbo.Seats", "ID_Room", "dbo.Rooms", "ID_Room", cascadeDelete: true);
            AddForeignKey("dbo.Schedules", "ID_Schedule", "dbo.Schedule_Room_Movie", "ID_Schedule_Room_Movie");
            AddForeignKey("dbo.Purchase_Seat", "ID_Seat", "dbo.Seats", "ID_Seat", cascadeDelete: true);
            AddForeignKey("dbo.Purchases", "ID_Schedule_Room_Movie", "dbo.Schedule_Room_Movie", "ID_Schedule_Room_Movie", cascadeDelete: true);
            AddForeignKey("dbo.Purchase_Seat", "ID_Purchase", "dbo.Purchases", "ID_Purchase", cascadeDelete: true);
            AddForeignKey("dbo.Rooms", "ID_Room", "dbo.Schedule_Room_Movie", "ID_Schedule_Room_Movie");
            AddForeignKey("dbo.Movies", "ID_Movie", "dbo.Schedule_Room_Movie", "ID_Schedule_Room_Movie");
        }
    }
}
