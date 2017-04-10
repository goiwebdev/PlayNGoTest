namespace Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Core.EmployeeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Core.EmployeeContext";
        }

        protected override void Seed(Core.EmployeeContext context)
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
                new Employee { LastName = "Lugnasin", FirstName = "Erwin",
                    ContactNumber = 1234, EmailAddress = "erwinlugnasin@gmail.com" },
                new Employee { LastName = "WebDev", FirstName = "Goi",
                    ContactNumber = 12345, EmailAddress = "erwinlugnasin@gmail.com" }
                );
 
        }
    }
}
