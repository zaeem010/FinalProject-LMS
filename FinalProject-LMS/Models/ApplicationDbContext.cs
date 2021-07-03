﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace FinalProject_LMS.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<ActivityType> ActivityTypes { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<UMessage> UMessages { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<QuizChild> QuizChild { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<TestChild> TestChild { get; set; }


        public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

 
    }
}

        
