namespace GroceryStoreDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGemstones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Color = c.String(),
                        Carat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoneProducts",
                c => new
                    {
                        Stone_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Stone_Id, t.Product_Id })
                .ForeignKey("dbo.Stones", t => t.Stone_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Stone_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoneProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.StoneProducts", "Stone_Id", "dbo.Stones");
            DropIndex("dbo.StoneProducts", new[] { "Product_Id" });
            DropIndex("dbo.StoneProducts", new[] { "Stone_Id" });
            DropTable("dbo.StoneProducts");
            DropTable("dbo.Stones");
        }
    }
}
