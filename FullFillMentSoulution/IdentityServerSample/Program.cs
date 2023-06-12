using DotNetCore.EntityFrameworkCore;
using DotNetCore.Repositories;
using IdentityCommon.Models.ForApplicationUser;
using IdentityServerSample;
using IdentityServerTest.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using 계정Common.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
IConfiguration Configuration = builder.Configuration;
builder.Services.Configure<JwtOptions>(Configuration.GetSection("JwtOptions"));
builder.Services.AddScoped<JwtTokenProvider>();
var ApplicationDbConnectionString = builder.Configuration.GetConnectionString("ApplicationDbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(ApplicationDbConnectionString));

// Identity 서비스 등록
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllers();
// Add services to the container.

var jwtOptions = Configuration.GetSection("JwtOptions").Get<JwtOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
                // 추가 옵션 설정
                // ...
            };
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<UserManager<ApplicationUser>>();
builder.Services.AddScoped<RoleManager<IdentityRole>>();
builder.Services.AddScoped<PasswordValidator<ApplicationUser>>();

builder.Services.AddScoped<ICommandRepository<ApplicationUser>, ApplicationUserRepository>();
builder.Services.AddScoped<IQueryRepository<ApplicationUser>, ApplicationUserRepository>();

builder.Services.AddScoped<ICommandRepository<IdentityRole>, IdentityRoleRepository>();
builder.Services.AddScoped<IQueryRepository<IdentityRole>, IdentityRoleRepository>();

builder.Services.AddScoped<IdentityRoleRepository>();
builder.Services.AddScoped<IdentityRoleClaimRepository>();
builder.Services.AddScoped<IdentityUserRoleRepository>();
builder.Services.AddScoped<IdentityUserTokenRepository>();
builder.Services.AddScoped<IdentityUserClaimRepository>();
builder.Services.AddScoped<IdentityUserLoginRepository>();
builder.Services.AddScoped<UnitOfWork<ApplicationDbContext>>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        builder =>
        {
            builder.WithOrigins("https://localhost:7284")
                .AllowAnyHeader()
                .AllowAnyMethod();
            builder.WithOrigins("https://localhost:7299")
            .AllowAnyHeader()
                .AllowAnyMethod();
            builder.WithOrigins("https://localhost:7114")
            .AllowAnyHeader()
                .AllowAnyMethod();
        });
    
});

        });
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors("MyPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
