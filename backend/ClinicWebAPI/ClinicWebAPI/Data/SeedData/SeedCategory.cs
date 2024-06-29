using ClinicWebAPI.Configs;
using ClinicWebAPI.Models;

namespace ClinicWebAPI.Data.SeedData
{
    public class SeedCategory
    {
        public static async Task CategorySeed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();

                if(!dataContext.Categories.Any())
                {
                    dataContext.Categories.AddRange(new Category[]
                    {
                        new Category { Name = "Thực phẩm bảo vệ sức khỏe"},
                        new Category { Name = "Thuốc an thần"},
                        new Category { Name = "Thuốc chống dị ứng"},
                        new Category { Name = "Thuốc chống đau"},
                        new Category { Name = "Thuốc giảm cân"},
                        new Category { Name = "Thuốc ho"},
                        new Category { Name = "Thuốc hoá trị"},
                        new Category { Name = "Thuốc kháng sinh"},
                        new Category { Name = "Thuốc kháng viêm"},
                        new Category { Name = "Thuốc kích thích"},
                        new Category { Name = "Thuốc ngủ"},
                        new Category { Name = "Thuốc nhuận tràng"},
                        new Category { Name = "Thuốc sát trùng"},
                        new Category { Name = "Thuốc tăng cường miễn dịch"},
                        new Category { Name = "Thuốc tiêu hóa"},
                        new Category { Name = "Thuốc tiểu đường"},
                        new Category { Name = "Thuốc tim mạch"},
                        new Category { Name = "Thuốc điều trị ung thư"},
                        new Category { Name = "Vitamin"},
                    });
                    await dataContext.SaveChangesAsync();
                }
            }
        }
    }
}
