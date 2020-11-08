namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            Database.SetInitializer<BlogContext>(new DropCreateDatabaseIfModelChanges<BlogContext>());

        }

        protected override void Seed(WebApplication1.Models.BlogContext context)
        {
            

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
