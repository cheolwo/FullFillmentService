using IdentityCommon.Models.ForApplicationUser;
using IdentityServerTest.Data;
using KoreaCommon.Model;
using KoreaCommon.Model.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ����Server.Manager;
using �ؾ�����.API.For��������;
using �ؾ�����.API.For��������â��;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
