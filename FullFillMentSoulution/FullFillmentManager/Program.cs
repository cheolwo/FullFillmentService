using FullFillmentManager;
using FullFillmentManager.Data;
using IdentityCommon.Models.ForApplicationUser;
using IdentityServerTest.Data;
using KoreaCommon.Fish.산지조합위판장.해양수산부산지조합정보;
using KoreaCommon.Fish.수협산지조합위판장.For산지조합위판장정보;
using KoreaCommon.Fish.수협산지조합위판장.위판장현황;
using KoreaCommon.Fish.해양수산부.For산지조합창고정보;
using KoreaCommon.Fish.해양수산부.For위판장별위탁판매현황;
using KoreaCommon.Fish.해양수산부.For조합창고품목별입출고현황;
using KoreaCommon.Fish.해양수산부.For조합창고품목별재고현황;
using KoreaCommon.Fish.해양수산부.For품목별물류센터재고현황;
using KoreaCommon.ViewModel.해양수산부;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var ApplicationDbConnectionString = builder.Configuration.GetConnectionString("ApplicationDbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(ApplicationDbConnectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddMudServices();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Login";
            options.AccessDeniedPath = "/AccessDenied";
        });
builder.Services.AddScoped<PasswordValidator<ApplicationUser>>();
builder.Services.AddScoped<AuthenticationStateProvider,
    CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<ExampleService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<산지조합ViewModel>();
builder.Services.AddScoped<산지조합API>();

builder.Services.AddScoped<산지조합위판장ViewModel>();
builder.Services.AddScoped<산지조합위판장API>();

builder.Services.AddScoped<산지조합위판장현황ViewModel>();
builder.Services.AddScoped<산지조합위판장현황API>();

builder.Services.AddScoped<산지조합창고ViewModel>();
builder.Services.AddScoped<산지조합창고API>();

builder.Services.AddScoped<위판장별위탁판매현황ViewModel>();
builder.Services.AddScoped<위판장별위탁판매현황API>();

builder.Services.AddScoped<조합창고품목별입출고현황ViewModel>();
builder.Services.AddScoped<조합창고품목별입출고현황API>();

builder.Services.AddScoped<조합창고품목별재고현황ViewModel>();
builder.Services.AddScoped<조합창고품목별재고현황API>();

builder.Services.AddScoped<품목별물류센터재고현황ViewModel>();
builder.Services.AddScoped<품목별물류센터재고현황API>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
