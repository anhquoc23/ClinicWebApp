using ClinicWebAPI.Configs;
using ClinicWebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace ClinicWebAPI.Data.SeedData
{
    public class SeedNurse
    {
        public static async Task SeedUser(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetService<DataContext>();
                var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
                var filePath = folderPath + @"\SeedNurse.txt";
                Console.WriteLine(filePath);
                using (var stream = new StreamReader(filePath))
                {
                    var line = stream.ReadLine();
                    while (line != null)
                    {
                        var info = line.Split('#');
                        var user = new User
                        {
                            FirstName = info[0],
                            LastName = info[1],
                            Avatar = info[2],
                            Address = info[3],
                            UserName = info[4],
                            Email = info[5],
                            PhoneNumber = info[6],
                        };
                        await userManager.CreateAsync(user, "Clinic@123");
                        await userManager.AddToRoleAsync(user, "NURSE");
                        line = stream.ReadLine();
                    }
                }
            }
        }
    }
}
