using ClinicWebAPI.Configs;
using ClinicWebAPI.Data;
using ClinicWebAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Services Database
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// Services Identity
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Clinic API",
        Version = "v1",
        Description = "List APIs for Clinic Swagger",
        TermsOfService = new Uri("http://localhost:5238/"),
        Contact = new OpenApiContact
        {
            Name = "Nguyễn Anh Quốc",
            Email = "nguyenah316@gmail.com",
            Url = new Uri("https://github.com/anhquoc23")
        }
    });
});

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower().Equals("seeddata"))
{
    await Seed.SeddData(app);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
