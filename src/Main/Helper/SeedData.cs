using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Helper
{
    public static class SeedData
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var r = new Role("Admin");

            var u = new User
            {
                Name = "Riesner",
                Vorname = "Rene",
                Username = "rr1980",
                Password = "12003"
            };

            var rtu = new RoleToUser()
            {
                Role = r,
                User = u

            };

            context.RoleToUsers.Add(rtu);




            //u.Roles = new List<Role>() { r };

            //context.Users.Add(u);

            context.SaveChanges();

        }
    }
}
