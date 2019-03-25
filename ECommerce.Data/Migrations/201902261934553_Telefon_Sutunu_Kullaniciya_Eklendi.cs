namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Telefon_Sutunu_Kullaniciya_Eklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Phone", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Phone");
        }
    }
}
