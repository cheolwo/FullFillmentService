using IdentityCommon.Models.ForApplicationUser;
using IdentityServerSample;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using 계정Common.Models;
using 창고Common;
using 창고Common.Repository;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;
//builder.Services.Configure<JwtOptions>(Configuration.GetSection("JwtOptions"));
//builder.Services.AddScoped<JwtTokenProvider>();
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        var jwtOptions = Configuration.GetSection("JwtOptions").Get<JwtOptions>();
//        var key = Encoding.ASCII.GetBytes(jwtOptions.SecretKey);

//        options.RequireHttpsMetadata = false;
//        options.SaveToken = true;
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = jwtOptions.Issuer,
//            ValidAudience = jwtOptions.Audience,
//            IssuerSigningKey = new SymmetricSecurityKey(key)
//        };
//    });
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<UserManager<ApplicationUser>>();
//builder.Services.AddScoped<RoleManager<IdentityRole>>();
//builder.Services.AddScoped<PasswordValidator<ApplicationUser>>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<창고Repository>();
builder.Services.AddScoped<창고상품Repository>();
builder.Services.AddScoped<입고상품Repository>();
builder.Services.AddScoped<적재상품Repository>();
builder.Services.AddScoped<출고상품Repository>();
builder.Services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

var 창고DbConnectionString = builder.Configuration.GetConnectionString("창고DbConnection");
builder.Services.AddDbContext<창고DbContext>(options =>
    options.UseMySQL(창고DbConnectionString));
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

//var ApplicationDbConnectionString = builder.Configuration.GetConnectionString("ApplicationDbConnection");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseMySQL(ApplicationDbConnectionString));
builder.Services.AddMemoryCache();
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
