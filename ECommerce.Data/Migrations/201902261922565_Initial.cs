namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 250),
                        City = c.String(nullable: false, maxLength: 250),
                        Country = c.String(nullable: false, maxLength: 250),
                        PostCode = c.String(maxLength: 50),
                        Company = c.String(maxLength: 250),
                        TaxNo = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Guid = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        LastName = c.String(nullable: false, maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 250),
                        UserName = c.String(maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 250),
                        CargoAddressId = c.Int(),
                        BillingAddressId = c.Int(),
                        ApprovedEmail = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        LastLoginDate = c.String(maxLength: 250),
                        LastLoginIp = c.String(maxLength: 250),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.BillingAddressId)
                .ForeignKey("dbo.Address", t => t.CargoAddressId)
                .Index(t => t.CargoAddressId)
                .Index(t => t.BillingAddressId);
            
            CreateTable(
                "dbo.Basket",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.UserId, t.ProductId })
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Visibility = c.Boolean(nullable: false),
                        ProductName = c.String(nullable: false, maxLength: 250),
                        ShortDescription = c.String(nullable: false, maxLength: 250),
                        Description = c.String(nullable: false),
                        StockActive = c.Boolean(nullable: false),
                        StockCount = c.Int(),
                        Slug = c.String(nullable: false, maxLength: 250),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PastPrice = c.Decimal(precision: 18, scale: 2),
                        SpecialPrice = c.Decimal(precision: 18, scale: 2),
                        SpecialPriceStartDate = c.DateTime(),
                        SpecialPriceFinishDate = c.DateTime(),
                        ShippingTimeId = c.Int(),
                        StockCode = c.String(maxLength: 250),
                        AdminComment = c.String(maxLength: 250),
                        UserId = c.Int(nullable: false),
                        Deleted = c.Boolean(),
                        DeletedUserId = c.Int(),
                        LastUpdateUserId = c.Int(),
                        UpdateDate = c.DateTime(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.LastUpdateUserId)
                .ForeignKey("dbo.ShippingTime", t => t.ShippingTimeId)
                .ForeignKey("dbo.User", t => t.DeletedUserId)
                .Index(t => t.ShippingTimeId)
                .Index(t => t.UserId)
                .Index(t => t.DeletedUserId)
                .Index(t => t.LastUpdateUserId);
            
            CreateTable(
                "dbo.Category_Product_Mapping",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Queue = c.Int(nullable: false),
                        SpecialProduct = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryId, t.ProductId })
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: false)
                .Index(t => t.CategoryId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        ShortDescription = c.String(nullable: false, maxLength: 250),
                        Description = c.String(nullable: false),
                        ParentCategoryId = c.Int(),
                        PhotoId = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Slag = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photo", t => t.PhotoId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.PhotoId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FolderId = c.Int(),
                        FileUrl = c.String(nullable: false, maxLength: 50),
                        UserId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProductPhoto",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        PhotoId = c.Int(nullable: false),
                        Queue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.PhotoId })
                .ForeignKey("dbo.Photo", t => t.PhotoId, cascadeDelete: false)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: false)
                .Index(t => t.ProductId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.OrderProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RealPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: false)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: false)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Guid = c.Guid(nullable: false),
                        UserId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RealPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BillingAddressId = c.Int(nullable: false),
                        CargoAddressId = c.Int(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ShippingTime",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShippingTime = c.String(nullable: false, maxLength: 250),
                        ColorCode = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhotoFolder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "UserId", "dbo.User");
            DropForeignKey("dbo.Basket", "UserId", "dbo.User");
            DropForeignKey("dbo.Basket", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "DeletedUserId", "dbo.User");
            DropForeignKey("dbo.Product", "ShippingTimeId", "dbo.ShippingTime");
            DropForeignKey("dbo.OrderProduct", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderProduct", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "UserId", "dbo.User");
            DropForeignKey("dbo.Product", "LastUpdateUserId", "dbo.User");
            DropForeignKey("dbo.Product", "UserId", "dbo.User");
            DropForeignKey("dbo.Category_Product_Mapping", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Category_Product_Mapping", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Category", "UserId", "dbo.User");
            DropForeignKey("dbo.Category", "PhotoId", "dbo.Photo");
            DropForeignKey("dbo.Photo", "UserId", "dbo.User");
            DropForeignKey("dbo.ProductPhoto", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductPhoto", "PhotoId", "dbo.Photo");
            DropForeignKey("dbo.User", "CargoAddressId", "dbo.Address");
            DropForeignKey("dbo.User", "BillingAddressId", "dbo.Address");
            DropIndex("dbo.Order", new[] { "UserId" });
            DropIndex("dbo.OrderProduct", new[] { "ProductId" });
            DropIndex("dbo.OrderProduct", new[] { "OrderId" });
            DropIndex("dbo.ProductPhoto", new[] { "PhotoId" });
            DropIndex("dbo.ProductPhoto", new[] { "ProductId" });
            DropIndex("dbo.Photo", new[] { "UserId" });
            DropIndex("dbo.Category", new[] { "UserId" });
            DropIndex("dbo.Category", new[] { "PhotoId" });
            DropIndex("dbo.Category_Product_Mapping", new[] { "ProductId" });
            DropIndex("dbo.Category_Product_Mapping", new[] { "CategoryId" });
            DropIndex("dbo.Product", new[] { "LastUpdateUserId" });
            DropIndex("dbo.Product", new[] { "DeletedUserId" });
            DropIndex("dbo.Product", new[] { "UserId" });
            DropIndex("dbo.Product", new[] { "ShippingTimeId" });
            DropIndex("dbo.Basket", new[] { "ProductId" });
            DropIndex("dbo.Basket", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "BillingAddressId" });
            DropIndex("dbo.User", new[] { "CargoAddressId" });
            DropIndex("dbo.Address", new[] { "UserId" });
            DropTable("dbo.PhotoFolder");
            DropTable("dbo.ShippingTime");
            DropTable("dbo.Order");
            DropTable("dbo.OrderProduct");
            DropTable("dbo.ProductPhoto");
            DropTable("dbo.Photo");
            DropTable("dbo.Category");
            DropTable("dbo.Category_Product_Mapping");
            DropTable("dbo.Product");
            DropTable("dbo.Basket");
            DropTable("dbo.User");
            DropTable("dbo.Address");
        }
    }
}
