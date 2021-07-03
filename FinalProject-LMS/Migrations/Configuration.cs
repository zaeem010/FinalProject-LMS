namespace FinalProject_LMS.Migrations
{
    using FinalProject_LMS.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalProject_LMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FinalProject_LMS.Models.ApplicationDbContext context)
        {

            var Net = new Course()
            {
                Name = ".Net",
                Description = ".Net...",
                StartDate = DateTime.Now
            };
            context.Courses.AddOrUpdate(Net);

            var Java = new Course()
            {
                Name = "Java",
                Description = "Java...",
                StartDate = DateTime.Now
            };
            context.Courses.AddOrUpdate(Java);

            var IT = new Course()
            {
                Name = "IT-Support",
                Description = "IT-Support...",
                StartDate = DateTime.Now
            };
            context.Courses.AddOrUpdate(IT);

            var Paython = new Course()
            {
                Name = "Python",
                Description = "Python...",
                StartDate = DateTime.Now
            };
            context.Courses.AddOrUpdate(Paython);

            var WebDesign = new Course()
            {
                Name = "Web Design",
                Description = "Web Design...",
                StartDate = DateTime.Now
            };
            context.Courses.AddOrUpdate(WebDesign);

            var Networks = new Course()
            {
                Name = "Networks",
                Description = "Networks...",
                StartDate = DateTime.Now
            };
            context.Courses.AddOrUpdate(Networks);


            var Css = new Module()
            {
                Name = "Css",
                Description = "Css...",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3),
                CourseId = 1

            };
            context.Modules.AddOrUpdate(Css);


            var Css2 = new Module()
            {
                Name = "Css",
                Description = "Css...",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3),
                CourseId = 2

            };
            context.Modules.AddOrUpdate(Css2);

            var Css3 = new Module()
            {
                Name = "Css",
                Description = "Css...",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3),
                CourseId = 4

            };
            context.Modules.AddOrUpdate(Css3);

            var Css4 = new Module()
            {
                Name = "Css",
                Description = "Css...",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3),
                CourseId = 5

            };
            context.Modules.AddOrUpdate(Css4);



            var Html = new Module()
            {
                Name = "HTML",
                Description = "HTML...",
                StartDate = DateTime.Now.AddDays(4),
                EndDate = DateTime.Now.AddDays(8),
                CourseId = 1

            };
            context.Modules.AddOrUpdate(Html);

            var Html2 = new Module()
            {
                Name = "HTML",
                Description = "HTML...",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3),
                CourseId = 2

            };
            context.Modules.AddOrUpdate(Html2);

            var Html3 = new Module()
            {
                Name = "HTML",
                Description = "HTML...",
                StartDate = DateTime.Now.AddDays(4),
                EndDate = DateTime.Now.AddDays(8),
                CourseId = 4

            };
            context.Modules.AddOrUpdate(Html3);

            var Html4 = new Module()
            {
                Name = "HTML",
                Description = "HTML...",
                StartDate = DateTime.Now.AddDays(4),
                EndDate = DateTime.Now.AddDays(8),
                CourseId = 5

            };
            context.Modules.AddOrUpdate(Html4);

            var Windows = new Module()
            {
                Name = "Windows Format",
                Description = "Back up...",
                StartDate = DateTime.Now.AddDays(4),
                EndDate = DateTime.Now.AddDays(8),
                CourseId = 3

            };
            context.Modules.AddOrUpdate(Windows);

            var Ip = new Module()
            {
                Name = "IP config",
                Description = "IP config...",
                StartDate = DateTime.Now.AddDays(4),
                EndDate = DateTime.Now.AddDays(8),
                CourseId = 6

            };
            context.Modules.AddOrUpdate(Ip);

            var Lerning = new ActivityType()
            {
                Name = "E-Learning"
            };

            context.ActivityTypes.AddOrUpdate(Lerning);


            var Assign = new ActivityType()
            {
                Name = "Assignment"
            };

            context.ActivityTypes.AddOrUpdate(Assign);


            var Exercise = new ActivityType()
            {
                Name = "Exercise"
            };

            context.ActivityTypes.AddOrUpdate(Exercise);










            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            var emails = new[] {"John@gmail.com", "Aderian@gmail.com","Anette@gmail.com","Johan@gmail.com","Ulrika@gmail.com", "Andreas@gmail.com",
                "Madiha@gmail.com" ,"Amer@gmail.com","Kathy@gmail.com", "Zafar@gmail.com","Ahmad@gmail.com","Noori@gmail.com", "Ehab@gmail.com",
                "Naji@gmail.com", "Awras@gmail.com", "Linda@gmail.com", "Megna@gmail.com","Evet@gmail.com","Boyan@gmail.com","Olof@gmail.com","Ravi@gmail.com","Nour@gmail.com" };

            foreach (var email in emails)
            {
                int position = email.IndexOf("@");
                if (position < 0)
                    continue;
                string userName = email.Substring(0, position);

                if (context.Users.Any(u => u.UserName == email)) continue;

                var user = new ApplicationUser { UserName = email, Email = email, Name = userName };
                var result = userManager.Create(user, "M@ster9");
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
            }


            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roleNames = new[] { "Teacher", "Student" };
            foreach (var roleName in roleNames)
            {
                if (context.Roles.Any(r => r.Name == roleName)) continue;

                var role = new IdentityRole { Name = roleName };
                var result = roleManager.Create(role);
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
            }



            var John = userManager.FindByName("John@gmail.com");
            userManager.AddToRole(John.Id, "Teacher");

            var Aderian = userManager.FindByName("Aderian@gmail.com");
            userManager.AddToRole(Aderian.Id, "Teacher");

            var Anette = userManager.FindByName("Anette@gmail.com");
            userManager.AddToRole(Anette.Id, "Teacher");

            var Johan = userManager.FindByName("Johan@gmail.com");
            userManager.AddToRole(Johan.Id, "Teacher");

            var Ulrika = userManager.FindByName("Ulrika@gmail.com");
            userManager.AddToRole(Ulrika.Id, "Teacher");

            var Andreas = userManager.FindByName("Andreas@gmail.com");
            Andreas.CourseId = 1;
            userManager.AddToRole(Andreas.Id, "Student");

            var Madiha = userManager.FindByName("Madiha@gmail.com");
            Madiha.CourseId = 1;
            userManager.AddToRole(Madiha.Id, "Student");

            var Amer = userManager.FindByName("Amer@gmail.com");
            Amer.CourseId = 1;
            userManager.AddToRole(Amer.Id, "Student");

            var Kathy = userManager.FindByName("Kathy@gmail.com");
            Kathy.CourseId = 2;
            userManager.AddToRole(Kathy.Id, "Student");

            var Zafar = userManager.FindByName("Zafar@gmail.com");
            Zafar.CourseId = 2;
            userManager.AddToRole(Zafar.Id, "Student");

            var Ahmad = userManager.FindByName("Ahmad@gmail.com");
            Ahmad.CourseId = 2;
            userManager.AddToRole(Ahmad.Id, "Student");

            var Noori = userManager.FindByName("Noori@gmail.com");
            Noori.CourseId = 3;
            userManager.AddToRole(Noori.Id, "Student");

            var Ehab = userManager.FindByName("Ehab@gmail.com");
            Ehab.CourseId = 3;
            userManager.AddToRole(Ehab.Id, "Student");

            var Naji = userManager.FindByName("Naji@gmail.com");
            Naji.CourseId = 3;
            userManager.AddToRole(Naji.Id, "Student");

            var Awras = userManager.FindByName("Awras@gmail.com");
            Awras.CourseId = 4;
            userManager.AddToRole(Awras.Id, "Student");

            var Linda = userManager.FindByName("Linda@gmail.com");
            Linda.CourseId = 4;
            userManager.AddToRole(Linda.Id, "Student");

            var Megna = userManager.FindByName("Megna@gmail.com");
            Megna.CourseId = 5;
            userManager.AddToRole(Megna.Id, "Student");

            var Evet = userManager.FindByName("Evet@gmail.com");
            Evet.CourseId = 5;
            userManager.AddToRole(Evet.Id, "Student");

            var Boyan = userManager.FindByName("Boyan@gmail.com");
            Boyan.CourseId = 5;
            userManager.AddToRole(Boyan.Id, "Student");

            var Olof = userManager.FindByName("Olof@gmail.com");
            Olof.CourseId = 6;
            userManager.AddToRole(Olof.Id, "Student");

            var Ravi = userManager.FindByName("Ravi@gmail.com");
            Ravi.CourseId = 6;
            userManager.AddToRole(Ravi.Id, "Student");

            var Nour = userManager.FindByName("Nour@gmail.com");
            Nour.CourseId = 6;
            userManager.AddToRole(Nour.Id, "Student");



            var Intro = new Activity()
            {
                Name = "Introduction",
                TypeId = 1,
                StartTime = DateTime.ParseExact("08:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                EndTime = DateTime.ParseExact("10:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                ModuleId = 1

            };
            context.Activities.AddOrUpdate(Intro);



            var Intro1 = new Activity()
            {
                Name = "Introduction",
                TypeId = 1,
                StartTime = DateTime.ParseExact("08:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                EndTime = DateTime.ParseExact("10:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                ModuleId = 2

            };
            context.Activities.AddOrUpdate(Intro1);

            var Intro3 = new Activity()
            {
                Name = "Introduction",
                TypeId = 1,
                StartTime = DateTime.ParseExact("08:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                EndTime = DateTime.ParseExact("10:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                ModuleId = 3

            };
            context.Activities.AddOrUpdate(Intro3);


            var Intro4 = new Activity()
            {
                Name = "Introduction",
                TypeId = 1,
                StartTime = DateTime.ParseExact("08:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                EndTime = DateTime.ParseExact("10:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                ModuleId = 4

            };
            context.Activities.AddOrUpdate(Intro4);


            var Intro5 = new Activity()
            {
                Name = "Introduction",
                TypeId = 1,
                StartTime = DateTime.ParseExact("08:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                EndTime = DateTime.ParseExact("10:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                ModuleId = 5

            };
            context.Activities.AddOrUpdate(Intro5);


            var Intro6 = new Activity()
            {
                Name = "Introduction",
                TypeId = 1,
                StartTime = DateTime.ParseExact("08:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                EndTime = DateTime.ParseExact("10:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                ModuleId = 6

            };
            context.Activities.AddOrUpdate(Intro6);


            var Intro7 = new Activity()
            {
                Name = "Introduction",
                TypeId = 1,
                StartTime = DateTime.ParseExact("08:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                EndTime = DateTime.ParseExact("10:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                ModuleId = 7

            };
            context.Activities.AddOrUpdate(Intro7);

            var Intro8 = new Activity()
            {
                Name = "Introduction",
                TypeId = 1,
                StartTime = DateTime.ParseExact("08:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                EndTime = DateTime.ParseExact("10:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                ModuleId = 8

            };
            context.Activities.AddOrUpdate(Intro8);


            var Intro9 = new Activity()
            {
                Name = "Introduction",
                TypeId = 1,
                StartTime = DateTime.ParseExact("08:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                EndTime = DateTime.ParseExact("10:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                ModuleId = 9

            };
            context.Activities.AddOrUpdate(Intro9);


            var Intro10 = new Activity()
            {
                Name = "Introduction",
                TypeId = 1,
                StartTime = DateTime.ParseExact("08:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                EndTime = DateTime.ParseExact("10:30 AM", "hh:mm tt", CultureInfo.InvariantCulture),
                ModuleId = 10

            };
            context.Activities.AddOrUpdate(Intro10);

            var Example = new Activity()
            {
                Name = "Example",
                TypeId = 3,
                StartTime = DateTime.ParseExact("10:30:00 AM", "hh:mm:ss tt", CultureInfo.InvariantCulture),
                EndTime = DateTime.ParseExact("10:30:00 AM", "hh:mm:ss tt", CultureInfo.InvariantCulture),
                ModuleId = 1

            };
            context.Activities.AddOrUpdate(Example);


        }
    }
}



