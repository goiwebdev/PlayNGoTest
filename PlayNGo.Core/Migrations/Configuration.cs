namespace PlayNGo.Core.Migrations
{
    using Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PlayNGo.Core.Context.PlayNGoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PlayNGo.Core.Context.PlayNGoContext";
        }

        protected override void Seed(PlayNGo.Core.Context.PlayNGoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Employees.AddOrUpdate(p => p.Id,
                            new Employee
                            {
                                LastName = "Lugnasin",
                                FirstName = "Erwin",
                                ContactNumber = 1234,
                                EmailAddress = "erwinlugnasin@gmail.com"
                            },
                            new Employee
                            {
                                LastName = "WebDev",
                                FirstName = "Goi",
                                ContactNumber = 12345,
                                EmailAddress = "erwinlugnasin@gmail.com"
                            }
                            );

        }
    }
}
