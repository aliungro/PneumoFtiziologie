using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hospital.Models
{
    public static class ApplicationDbContextExtensions
    {
        public static void CreateRole(this ApplicationDbContext db, string newRole)
        {
            var roleStore = new RoleStore<IdentityRole>(db);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var role = roleManager.FindByName(newRole);
            if (role == null)
            {
                role = new IdentityRole(newRole);
                roleManager.Create(role);
            }
        }
    }
}