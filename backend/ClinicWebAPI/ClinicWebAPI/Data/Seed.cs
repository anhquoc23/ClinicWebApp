using ClinicWebAPI.Configs;
using ClinicWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Asn1.X509;
using System.Globalization;

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
                        Avatar = "https\\://res.cloudinary.com/dvevyvqyt/image/upload/v1714633290/my1pxm0hwtg47onfzcoi.jpg"
                    };

                    await userManager.CreateAsync(user, "Admin@123");
                    context.SaveChanges();
                    await userManager.AddToRoleAsync(user, "ADMIN");
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedShift(IApplicationBuilder applicationBuilder) 
        { 
            using (var scope =  applicationBuilder.ApplicationServices.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetService<DataContext>();
                var format = @"hh\:mm";
                
                if (!dataContext.Shifts.Any())
                {
                    await dataContext.Shifts.AddRangeAsync(new Shift[]
                    {
                        new Shift
                        {
                            Name = "Ca 1",
                            TimeStart = TimeSpan.ParseExact("07:00", format, CultureInfo.InvariantCulture),
                            TimeEnd = TimeSpan.ParseExact("11:00", format, CultureInfo.InvariantCulture)
                        },
                        new Shift
                        {
                            Name = "Ca 2",
                            TimeStart = TimeSpan.ParseExact("13:00", format, CultureInfo.InvariantCulture),
                            TimeEnd = TimeSpan.ParseExact("17:00", format, CultureInfo.InvariantCulture)
                        },
                        new Shift
                        {
                            Name = "Ca 3",
                            TimeStart = TimeSpan.ParseExact("18:00", format, CultureInfo.InvariantCulture),
                            TimeEnd = TimeSpan.ParseExact("22:00", format, CultureInfo.InvariantCulture)
                        }
                    });
                    await dataContext.SaveChangesAsync();
                }
            }
        }

        public static async Task SeedRoom(IApplicationBuilder applicationBuilder)
        {
            using(var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetService<DataContext>();

                if(!dataContext.Rooms.Any())
                {
                    await dataContext.Rooms.AddRangeAsync(new Room[]
                    {
                        new Room  { Name = " Phòng 101" },
                        new Room  { Name = " Phòng 102" },
                        new Room  { Name = " Phòng 103" },
                        new Room  { Name = " Phòng 201" },
                        new Room  { Name = " Phòng 202" },
                        new Room  { Name = " Phòng 203" },
                        new Room  { Name = " Phòng 301" },
                        new Room  { Name = " Phòng 302" },
                        new Room  { Name = " Phòng 303" },
                        new Room  { Name = " Phòng A1" },
                        new Room  { Name = " Phòng A2" },
                        new Room  { Name = " Phòng B1" },
                        new Room  { Name = " Phòng B2" },
                    });
                    await dataContext.SaveChangesAsync();
                }
            }
        }
    }
}
