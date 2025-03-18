using ApiDemoBatch2.Context;
using ApiDemoBatch2.Repositories;
using ApiDemoBatch2.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Auto Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Services
builder.Services.AddScoped<ICarService, CarService>();

// Repositories
builder.Services.AddScoped<ICarRepository, CarRepository>();

// Database Configuration
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
string connectionString = "server=localhost; port=3306; database=api-test; user=root; password=2025root; SslMode=Required;Allow User Variables=true;";

builder.Services.AddDbContext<DatabaseContext>(
            dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion).EnableDetailedErrors()
        );

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
