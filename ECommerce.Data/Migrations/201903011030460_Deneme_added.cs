namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deneme_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Basket", "deneme", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Basket", "deneme");
        }
    }
}
