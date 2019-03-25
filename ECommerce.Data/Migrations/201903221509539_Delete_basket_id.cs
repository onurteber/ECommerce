namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete_basket_id : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Basket", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Basket", "Id", c => c.Int(nullable: false));
        }
    }
}
