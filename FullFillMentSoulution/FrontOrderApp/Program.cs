using 주문자App;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MVVMToolkit.Blazor.SampleApp.ViewModels;
using OrderCommon.Services;
using Quartz;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddScoped<OrderViewModel>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<OrderJob>();
builder.Services.AddApiAuthorization();

//builder.Services.AddApiAuthorization(options =>
//{
//    options.AuthenticationPaths.LogOutSucceededPath = ""; // 로그아웃 후 리디렉션할 경로를 지정할 수 있습니다.
//});
// Add services to the container

await builder.Build().RunAsync();
