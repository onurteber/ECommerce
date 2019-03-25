namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShowOnHomePage_Added_To_Product_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ShowOnHomePage", c => c.Boolean(nullable: false,defaultValue:false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ShowOnHomePage");
        }
    }
}
