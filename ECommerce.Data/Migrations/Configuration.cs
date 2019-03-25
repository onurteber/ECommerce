namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ECommerce.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ECommerce.Data.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Settings.Add(new Setting
            {
                Key = "UserNameActivated",
                Value = "false"
            });
            context.Settings.Add(new Setting
            {
                Key = "LoginEnabled",
                Value = "true"
            });

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
