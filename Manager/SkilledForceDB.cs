using Microsoft.EntityFrameworkCore;
using Skilled_Force.Models;

namespace Skilled_Force.Manager
{
    public class SkilledForceDB : DbContext
    {

        public DbSet<User> User { get; set; }

        public DbSet<Job> Job { get; set; }

        public DbSet<Role> Role { get; set; }

        public SkilledForceDB(DbContextOptions<SkilledForceDB> options)
            : base(options)
        {

        }
    }
}
