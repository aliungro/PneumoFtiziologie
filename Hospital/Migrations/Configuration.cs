using Hospital.Models;

namespace Hospital.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Hospital.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Hospital.Models.ApplicationDbContext context)
        {
            context.CreateRole("Administrator");
            context.CreateRole("Patient");
            context.CreateRole("Doctor");
        }
    }
}
