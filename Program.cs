using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuoteWorldAPI.Entities;
using QuoteWorldAPI.Entities.Seeders;
using QuoteWorldAPI.Services.Interfaces;
using QuoteWorldAPI.Services;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using QuoteWorldAPI.Repositories.Interfaces;
using QuoteWorldAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(new CompactJsonFormatter(), "./logs/myapp.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog(); // Use Serilog as the logging provider
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QuoteWorldContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuoteWorldConnectionString")));
builder.Services.AddScoped<QuoteDataSeeder>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IQuoteService, QuoteService>();
builder.Services.AddScoped<IQuoteRepository, QuoteRepository>();


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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seeder = services.GetRequiredService<QuoteDataSeeder>();
    seeder.SeedData();
}

app.Run();
