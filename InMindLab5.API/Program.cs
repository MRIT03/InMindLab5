﻿using Asp.Versioning;
using Hangfire;
using Hangfire.PostgreSql;
using InMindLab5.API;
using MediatR;
using InMindLab5.Application.Commands;
using InMindLab5.Domain.Entities;
using InMindLab5.Infrastructure.BackgroundJobs;
using InMindLab5.Persistence.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using InMindLab5.Persistence.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;


var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


// Add DbContext for PostgreSQL
builder.Services.AddDbContext<UmcContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("UniversityConnection")));


var redisConnection = builder.Configuration.GetValue<string>("Redis:ConnectionString");

builder.Services.AddMemoryCache();



builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnection));

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = redisConnection;
});



builder.Services.AddHangfire(config => config
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UsePostgreSqlStorage(builder.Configuration.GetConnectionString("HangfireConnection"))
);
builder.Services.AddHangfireServer();


builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IEmailService, EmailService>();


// Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AdminCreateCourseCommand).Assembly));

// Register Repositories
builder.Services.AddScoped<IRepository<Course>, CourseRepository>();
builder.Services.AddScoped<IRepository<Admin>, AdminRepository>();
builder.Services.AddScoped<IRepository<TeacherCourse>, TeacherCourseRepository>();
builder.Services.AddScoped<IRepository<Course>, CourseRepository>();
builder.Services.AddScoped<IRepository<Enroll>, EnrollRepository>();
builder.Services.AddScoped<IRepository<Teacher>, TeacherRepository>();
builder.Services.AddScoped<IRepository<Student>, StudentRepository>();
builder.Services.AddScoped<IBackgroundJobService, BackgroundJobService>();

builder.Services.AddControllers()
    .AddOData(options =>
    {
        options.Select().Filter().OrderBy().Count()
            .AddRouteComponents("api/v{version:apiVersion}/odata", EdmModelBuilder.GetEdmModel());
    });


builder.Services.AddApiVersioning().AddMvc();
builder.Services.AddApiVersioning().AddOData();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHangfireDashboard("/hangfire"); 
app.UseHangfireServer();

var jobService = app.Services.GetRequiredService<IBackgroundJobService>();

RecurringJob.AddOrUpdate(
    "hourly-job",
    () => jobService.RunHourlyJob(),
    Cron.Hourly
);

RecurringJob.AddOrUpdate(
    "daily-email-job",
    () => jobService.SendDailyEmails(),
    Cron.Daily(8)
);

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();