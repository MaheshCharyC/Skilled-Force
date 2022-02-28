using Microsoft.EntityFrameworkCore;
using Skilled_Force.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skilled_Force.Manager
{
    public class SkilledForceDB : DbContext
    {

        public DbSet<User> User { get; set; }

        public SkilledForceDB(DbContextOptions<SkilledForceDB> options)
            : base(options)
        {

        }
    }
}
