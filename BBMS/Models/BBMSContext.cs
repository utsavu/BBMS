using BBMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BBMS.Models
{
    public class BBMSContext:DbContext
    {
        public BBMSContext()
        {

        }
        public BBMSContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<BloodReq> BloodReqs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:wipro-rp.database.windows.net;Database=BBMS;User ID = yashraj;Password=#Yash2000;");
        }
    }
}
