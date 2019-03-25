namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Basket_add_Id : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Basket", "Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Basket", "Id");
        }
    }
}
