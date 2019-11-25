namespace GroceryStoreDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveTypeToTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JewerlyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql(
                  @"INSERT INTO dbo.JewerlyTypes SELECT p.Type FROM dbo.Products p GROUP BY p.Type"
                 );

            AddColumn("dbo.Products", "JewerlyType_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "JewerlyType_Id");

            Sql(@"UPDATE dbo.Products
                 SET dbo.Products.JewerlyType_Id = dbo.JewerlyTypes.Id
                 FROM Products
                 JOIN dbo.JewerlyTypes
                 ON dbo.JewerlyTypes.Name=dbo.Products.Type
                ");

            AddForeignKey("dbo.Products", "JewerlyType_Id", "dbo.JewerlyTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Type", c => c.String());

            Sql(@"UPDATE dbo.Products
                 SET dbo.Products.Type = dbo.JewerlyTypes.Name
                 FROM Products
                 JOIN dbo.JewerlyTypes
                 ON dbo.JewerlyTypes.Id=dbo.Products.JewerlyType_Id
                ");

            DropForeignKey("dbo.Products", "JewerlyType_Id", "dbo.JewerlyTypes");
            DropIndex("dbo.Products", new[] { "JewerlyType_Id" });
            DropColumn("dbo.Products", "JewerlyType_Id");
            DropTable("dbo.JewerlyTypes");
        }
    }
}
