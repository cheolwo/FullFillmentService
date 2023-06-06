using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderCommon.Model;
using OrderCommon.Repository;
using OrderCommon.Services;
using Quartz;
using System.Reflection;
using 주문Common.Services;
using 주문Common.Services.Command;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        builder =>
        {
            builder.WithOrigins("https://localhost:7291")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IEventQueue, EventQueue>();

builder.Services.AddScoped<주문자Repository>();
builder.Services.AddScoped<주문Repository>();
builder.Services.AddScoped<판매자상품Repository>();
builder.Services.AddScoped<판매자Repository>();
var OrderDbConnectionString = builder.Configuration.GetConnectionString("OrderDbConnection");
builder.Services.AddDbContext<주문DbContext>(options =>
    options.UseMySQL(OrderDbConnectionString));

builder.Services.AddSingleton<ProcessOrderJob>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddSingleton<IRequestHandler<Create주문Command, int>, Create주문CommandHandler >();
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    // Just use the name of your job that you created in the Jobs folder.
    var jobKey = new JobKey("ProcessOrderJob");
    q.AddJob<ProcessOrderJob>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("ProcessOrderJob-trigger")
        //This Cron interval can be described as "run every minute" (when second is zero)
        .WithCronSchedule("0 * * ? * *")
        .StartNow().WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromMilliseconds(1000)).RepeatForever())

    );
});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyPolicy");  // CORS 미들웨어 추가

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
