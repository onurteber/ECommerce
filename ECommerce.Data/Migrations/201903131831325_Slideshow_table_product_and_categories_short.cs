namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Slideshow_table_product_and_categories_short : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SlideShow",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoId = c.Int(nullable: false),
                        Title = c.String(nullable:true),
                        Description = c.String(nullable: true),
                        ButtonName = c.String(nullable: true),
                        ButtonLink = c.String(nullable: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Product", "Queue", c => c.Int(nullable: false,defaultValue:0));
            AddColumn("dbo.Category", "ShowHomePage", c => c.Boolean(nullable: false,defaultValue:false));
            AddColumn("dbo.Category", "Queue", c => c.Int(nullable: false,defaultValue:0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "Queue");
            DropColumn("dbo.Category", "ShowHomePage");
            DropColumn("dbo.Product", "Queue");
            DropTable("dbo.SlideShow");
        }
    }
}
