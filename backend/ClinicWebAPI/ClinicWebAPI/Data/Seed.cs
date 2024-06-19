using ClinicWebAPI.Configs;
using ClinicWebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace ClinicWebAPI.Data
{
    public class Seed
    {
        public static async Task SeddData(IApplicationBuilder builder1 )
        {
            using (var serviceScope = builder1.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                context.Database.EnsureCreated();

                //if (!context.Roles.Any())
                //{
                //    await roleManager.CreateAsync(new IdentityRole("ADMIN"));
                //    await roleManager.CreateAsync(new IdentityRole("DOCTOR"));
                //    await roleManager.CreateAsync(new IdentityRole("NURSE"));
                //    await roleManager.CreateAsync(new IdentityRole("PATIENT"));
                //    //context.Roles.AddRange(new IdentityRole[]
                //    //{
                //    //    new IdentityRole("ADMIN"),
                //    //    new IdentityRole("DOCTOR"),
                //    //    new IdentityRole("NURSE"),
                //    //    new IdentityRole("PATIENT")
                //    //});

                //    //context.SaveChanges();
                //}

                if (!context.Users.Any())
                {
                    var user = new User
                    {
                        FirstName = "ADMINISTRATOR",
                        LastName = "SYSTEM",
                        Email = "nguyenah316@gmail.com",
                        UserName = "admin",
                        Address = "Hồ Chí Minh",
                        PhoneNumber = "1234567890",
                        Avatar = "https://res.cloudinary.com/dvevyvqyt/image/upload/v1714633290/my1pxm0hwtg47onfzcoi.jpg"
                    };

                    await userManager.CreateAsync(user, "Admin@123");
                    context.SaveChanges();
                    await userManager.AddToRoleAsync(user, "ADMIN");
                    context.SaveChanges();
                }
            }
        }
    }
}
