using DotNetCore.EntityFrameworkCore;
using DotNetCore.Repositories;
using IdentityCommon.Models.ForApplicationUser;
using IdentityServerTest.Data;
using IdentityServerTest.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ApplicationDbConnectionString = builder.Configuration.GetConnectionString("ApplicationDbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(ApplicationDbConnectionString));

// Identity 서비스 등록
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<UserManager<ApplicationUser>>();
builder.Services.AddScoped<RoleManager<IdentityRole>>();
builder.Services.AddScoped<PasswordValidator<ApplicationUser>>();

builder.Services.AddScoped<ICommandRepository<ApplicationUser>, ApplicationUserRepository>();
builder.Services.AddScoped<IQueryRepository<ApplicationUser>, ApplicationUserRepository>();

builder.Services.AddScoped<ICommandRepository<IdentityRole>, IdentityRoleRepository>();
builder.Services.AddScoped<IQueryRepository<IdentityRole>, IdentityRoleRepository>();

//builder.Services.AddScoped<ICommandRepository<IdentityRoleClaim>, IdentityRoleClaimRepository>();
//builder.Services.AddScoped<IQueryRepository<IdentityRoleClaim>, IdentityRoleClaimRepository>();

//builder.Services.AddScoped<ICommandRepository<ApplicationUser>, ApplicationUserRepository>();
//builder.Services.AddScoped<IQueryRepository<ApplicationUser>, ApplicationUserRepository>();

//builder.Services.AddScoped<ICommandRepository<ApplicationUser>, ApplicationUserRepository>();
//builder.Services.AddScoped<IQueryRepository<ApplicationUser>, ApplicationUserRepository>();

//builder.Services.AddScoped<ICommandRepository<ApplicationUser>, ApplicationUserRepository>();
//builder.Services.AddScoped<IQueryRepository<ApplicationUser>, ApplicationUserRepository>();

//builder.Services.AddScoped<ICommandRepository<ApplicationUser>, ApplicationUserRepository>();
//builder.Services.AddScoped<IQueryRepository<ApplicationUser>, ApplicationUserRepository>();

builder.Services.AddScoped<IdentityRoleRepository>();
builder.Services.AddScoped<IdentityRoleClaimRepository>();
builder.Services.AddScoped<IdentityUserRoleRepository>();
builder.Services.AddScoped<IdentityUserTokenRepository>();
builder.Services.AddScoped<IdentityUserClaimRepository>();
builder.Services.AddScoped<IdentityUserLoginRepository>();
builder.Services.AddScoped<UnitOfWork<ApplicationDbContext>>();

var app = builder.Build();

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
