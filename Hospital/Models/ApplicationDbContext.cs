using Microsoft.AspNet.Identity.EntityFramework;

namespace Hospital.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Hospital.Models.Doctor> Doctors { get; set; }
        public System.Data.Entity.DbSet<Hospital.Models.Patient> Patients { get; set; }
        public System.Data.Entity.DbSet<Hospital.Models.Therapy> Therapies { get; set; }
        public System.Data.Entity.DbSet<Hospital.Models.Drug> Drugs { get; set; }
        public System.Data.Entity.DbSet<Hospital.Models.Appointment> Appointments { get; set; }
    }
}