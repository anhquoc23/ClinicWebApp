using ClinicWebAPI.Configs;
using ClinicWebAPI.Models;

namespace ClinicWebAPI.Data.SeedData
{
    public class SeedSpecialization
    {
        public static async Task SpecializationSeed(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
                if (!dataContext.Specializations.Any())
                {
                    await dataContext.Specializations.AddRangeAsync(new Specialization[]
                    {
                        new Specialization {Name = "Da liễu"},
                        new Specialization {Name = "Nhi khoa"},
                        new Specialization {Name = "Nội tiết"},
                        new Specialization {Name = "Tâm thần"},
                        new Specialization {Name = "Thần kinh"},
                        new Specialization {Name = "Tiêu hóa"},
                        new Specialization {Name = "Tim mạch"},
                        new Specialization {Name = "Ung thư"},
                    });
                    await dataContext.SaveChangesAsync();
                }
            }
        }
    }
}
