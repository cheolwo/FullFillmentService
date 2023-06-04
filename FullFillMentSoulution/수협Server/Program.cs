using IdentityCommon.Models.ForApplicationUser;
using IdentityServerTest.Data;
using KoreaCommon.Model;
using KoreaCommon.Model.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using 해양수산부.API.For산지조합;
using 해양수산부.API.For산지조합창고;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<산지조합창고API>();


builder.Services.AddScoped<산지조합API>();

builder.Services.AddScoped<수산협동조합Repository>();
builder.Services.AddScoped<수산품Repository>();
builder.Services.AddScoped<수산품별재고현황Repository>();
builder.Services.AddScoped<수산창고Repository>();
var 수협DbConnectionString = builder.Configuration.GetConnectionString("수협DbConnection");
builder.Services.AddDbContext<수협DbContext>(options =>
    options.UseMySQL(수협DbConnectionString));

var ApplicationDbConnectionString = builder.Configuration.GetConnectionString("ApplicationDbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(ApplicationDbConnectionString));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

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
