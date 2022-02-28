using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Skilled_Force.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skilled_Force.Manager
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SkilledForceDB(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SkilledForceDB>>()))
            {
                // Look for any movies.
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }

                context.User.AddRange(
                    new User
                    {
                        Email ="test@gmail.com",
                        UserId="test",
                        Password="test",
                        FirstName="TestF",
                        LastName="TestL",
                        Phone="0000000000"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
