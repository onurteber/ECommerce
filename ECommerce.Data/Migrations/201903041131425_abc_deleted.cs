namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc_deleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Basket", "abc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Basket", "abc", c => c.Int(nullable: false));
        }
    }
}
