﻿namespace NinjaDomain.DataModel.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<NinjaContext>
    {
        public Configuration()
        {
            //many downsides
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NinjaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
