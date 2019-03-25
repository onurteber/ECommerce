namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product_AddColumn_Viewed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Viewed", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Viewed");
        }
    }
}
