using Serilog;
using Serilog.AspNetCore;
using Serilog.Settings.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




//Add support to logging with SERILOG
IConfigurationRoot configuration = new ConfigurationBuilder()
 .AddJsonFile("appsettings.json", optional:false, reloadOnChange: true).Build();

var _logger = new Serilog.LoggerConfiguration()
    .ReadFrom.Configuration(configuration).CreateLogger();

builder.Logging.AddSerilog(_logger);




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
