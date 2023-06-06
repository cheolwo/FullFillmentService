using IdentityCommon.Models.ForApplicationUser;
using IdentityServerTest.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using 창고Common;
using 창고Common.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<창고Repository>();
builder.Services.AddScoped<창고상품Repository>();
builder.Services.AddScoped<입고상품Repository>();
builder.Services.AddScoped<적재상품Repository>();
builder.Services.AddScoped<출고상품Repository>();

var 창고DbConnectionString = builder.Configuration.GetConnectionString("창고DbConnection");
builder.Services.AddDbContext<창고DbContext>(options =>
    options.UseMySQL(창고DbConnectionString));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

var ApplicationDbConnectionString = builder.Configuration.GetConnectionString("ApplicationDbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(ApplicationDbConnectionString));

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
