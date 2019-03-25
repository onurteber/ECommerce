namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Basket", "abc", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Basket", "abc");
        }
    }
}
