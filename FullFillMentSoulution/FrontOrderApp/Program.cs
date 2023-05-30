using FrontOrderApp;
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

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    // Just use the name of your job that you created in the Jobs folder.
    var jobKey = new JobKey("OrderJob");
    q.AddJob<OrderJob>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("OrderJob-trigger")
        //This Cron interval can be described as "run every minute" (when second is zero)
        .WithCronSchedule("0 * * ? * *")
        .StartNow().WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromMilliseconds(1000)).RepeatForever())

    );
});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
await builder.Build().RunAsync();
