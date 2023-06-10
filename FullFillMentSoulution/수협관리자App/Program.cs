using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using 수협관리자App;
using 수협관리자AppCommon;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped<고객정보ViewModel>();
//builder.Services.AddScoped<배송현황ViewModel>();
//builder.Services.AddScoped<상품관리ViewModel>();
//builder.Services.AddScoped<입고현황ViewModel>();
//builder.Services.AddScoped<재고조정ViewModel>();
//builder.Services.AddScoped<주문현황ViewModel>();
//builder.Services.AddScoped<창고재고ViewModel>();
//builder.Services.AddScoped<출고대기ViewModel>();
//builder.Services.AddScoped<판매현황ViewModel>();
builder.Services.AddScoped<수협LoginViewModel>();
builder.Services.AddScoped<수협Actor>();
builder.Services.AddHttpClient();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

await builder.Build().RunAsync();
