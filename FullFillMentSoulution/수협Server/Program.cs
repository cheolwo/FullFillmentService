using IdentityCommon.Models.ForApplicationUser;
using IdentityServerSample;
using KoreaCommon.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ����Common.Models;
using ����Common.Repository;
using ����Server.Manager;
using �ؾ�����.API.For��������;
using �ؾ�����.API.For��������â��;

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
