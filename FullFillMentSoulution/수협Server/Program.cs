using IdentityCommon.Models.ForApplicationUser;
using IdentityServerSample;
using KoreaCommon.Fish.�ؾ�����;
using KoreaCommon.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Quartz;
using System.Text;
using ����Common.Models;
using ����Common.Repository;
using ����Server.Job;
using ����Server.Manager;
using �ؾ�����.API.For��������;
using �ؾ�����.API.For��������â��;
using �ؾ�����.API.For����â��ǰ�������Ȳ;

var builder = WebApplication.CreateBuilder(args);

IConfiguration Configuration = builder.Configuration;
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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<��������â��API>();
builder.Services.AddScoped<��������API>();
builder.Services.AddScoped<����â��ǰ�������ȲAPI>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<������������Repository>();
builder.Services.AddScoped<����ǰRepository>();
builder.Services.AddScoped<����ǰ�������ȲRepository>();
builder.Services.AddScoped<����â��Repository>();
builder.Services.AddScoped<����Manager>();

var ����DbConnectionString = builder.Configuration.GetConnectionString("����DbConnection");
builder.Services.AddDbContext<����DbContext>(options =>
    options.UseMySQL(����DbConnectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
    options =>
    {
        options.Password.RequireDigit = false; // ���� �ʼ� ����
        options.Password.RequireLowercase = false; // �ҹ��� �ʼ� ����
        options.Password.RequireUppercase = false; // �빮�� �ʼ� ����
        options.Password.RequireNonAlphanumeric = false; // Ư�� ���� �ʼ� ����
        options.Password.RequiredLength = 4; // ��й�ȣ �ּ� ����
    }
    ).AddEntityFrameworkStores<ApplicationDbContext>();

var ApplicationDbConnectionString = builder.Configuration.GetConnectionString("ApplicationDbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(ApplicationDbConnectionString));

builder.Services.AddScoped<I����â������ǰ����, ����APIToDbManager>();
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    // Just use the name of your job that you created in the Jobs folder.
    var jobKey = new JobKey("����â������ǰCollectingJob");
    q.AddJob<����â������ǰCollectingJob>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("����â������ǰCollectingJob-trigger")
        //This Cron interval can be described as "run every minute" (when second is zero)
        .WithCronSchedule("0 * * ? * *")
        .StartNow().WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromMilliseconds(1000)).RepeatForever())
        );
});

builder.Services.AddMemoryCache();
builder.Services.AddStackExchangeRedisCache(options => options.Configuration = "localhost:6379");
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
