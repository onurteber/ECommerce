namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Role_Added_To_User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Role");
        }
    }
}
