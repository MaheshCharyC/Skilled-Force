using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Skilled_Force.Models;
using System;
using System.Linq;

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
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }

                context.Role.AddRange(
                    new Role()
                    {
                        Name = "Seeker",
                        Description = "General user/job seeker"
                    }, 
                    new Role()
                    {
                        Name = "Recruiter",
                        Description = "General user/job provider"
                    },
                    new Role()
                    {
                        Name = "Admin",
                        Description = "Admin user"
                    }
                );

                context.User.AddRange(
                    new User
                    {
                        Email ="test@gmail.com",
                        UserId="test",
                        Password="test",
                        FirstName="TestF",
                        LastName="TestL",
                        RoleId=1,
                        Phone="0000000000"
                    },
                    new User
                    {
                        Email = "test1@gmail.com",
                        UserId = "test1",
                        Password = "test",
                        FirstName = "One",
                        LastName = "Test Last",
                        RoleId = 2,
                        Phone = "0000000000"
                    }
                );
                context.Job.AddRange(
                    new Job
                    {
                        Title = "Test Job 1",
                        Description = "Test data 2",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        CreatedBy = 1,
                        UpdatedBy = 1
                    }, new Job
                    {
                        Title = "Test Job 2",
                        Description = "Test data 2",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        CreatedBy = 1,
                        UpdatedBy = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
