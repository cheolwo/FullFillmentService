using IdentityCommon.Models.ForApplicationUser;
using IdentityServerSample;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderCommon.Model;
using OrderCommon.Repository;
using OrderCommon.Services;
using Quartz;
using System.Reflection;
using System.Text;
using ����Common.Models;
using �ֹ�Common.Command;
using �ֹ�Common.Event;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;

// ���� �������� ����
var ApplicationDbConnectionString = builder.Configuration.GetConnectionString("ApplicationDbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(ApplicationDbConnectionString));
builder.Services.Configure<JwtOptions>(Configuration.GetSection("JwtOptions"));
builder.Services.AddScoped<JwtTokenProvider>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtOptions = Configuration.GetSection("JwtOptions").Get<JwtOptions>();
        var key = Encoding.ASCII.GetBytes(jwtOptions.SecretKey);

        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();



// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        builder =>
        {
            builder.WithOrigins("https://localhost:7291")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
//builder.Services.AddScoped<UserManager<ApplicationUser>>();
//builder.Services.AddScoped<RoleManager<IdentityRole>>();
//builder.Services.AddScoped<PasswordValidator<ApplicationUser>>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IEventQueue, EventQueue>();

builder.Services.AddScoped<�ֹ���Repository>();
builder.Services.AddScoped<�ֹ�Repository>();
builder.Services.AddScoped<�Ǹ��ڻ�ǰRepository>();
builder.Services.AddScoped<�Ǹ���Repository>();
var OrderDbConnectionString = builder.Configuration.GetConnectionString("OrderDbConnection");
builder.Services.AddDbContext<�ֹ�DbContext>(options =>
    options.UseMySQL(OrderDbConnectionString));

builder.Services.AddSingleton<ProcessOrderJob>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddSingleton<IRequestHandler<Create�ֹ�Command, int>, Create�ֹ�CommandHandler >();
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    // Just use the name of your job that you created in the Jobs folder.
    var jobKey = new JobKey("ProcessOrderJob");
    q.AddJob<ProcessOrderJob>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("ProcessOrderJob-trigger")
        //This Cron interval can be described as "run every minute" (when second is zero)
        .WithCronSchedule("0 * * ? * *")
        .StartNow().WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromMilliseconds(1000)).RepeatForever())

    );
});
builder.Services.AddMemoryCache();
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();

app.UseHttpsRedirection();
//app.UseAuthentication();
//app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
