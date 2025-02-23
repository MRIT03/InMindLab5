using Asp.Versioning;
using MediatR;
using InMindLab5.Application.Commands;
using InMindLab5.Domain.Entities;
using InMindLab5.Persistence.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using InMindLab5.Persistence.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var defaultVersion = builder.Configuration.GetValue<string>("ApiVersioning:DefaultVersion") ?? "1.0";

var configuration = builder.Configuration;
builder.Services.AddApiVersioning().AddMvc();

// Add DbContext for PostgreSQL
builder.Services.AddDbContext<UmcContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("UniversityConnection")));

// Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AdminCreateCourseCommand).Assembly));

// Register Repositories
builder.Services.AddScoped<IRepository<Course>, CourseRepository>();
builder.Services.AddScoped<IRepository<Admin>, AdminRepository>();
builder.Services.AddScoped<IRepository<TeacherCourse>, TeacherCourseRepository>();
builder.Services.AddScoped<IRepository<Course>, CourseRepository>();
builder.Services.AddScoped<IRepository<Enroll>, EnrollRepository>();


builder.Services.AddControllers();




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();