using Microsoft.EntityFrameworkCore;
using Seman04EFCore.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;  //PASO 4
var _cnx = _config.GetConnectionString("DevConnection"); //PASO 5
builder //PASO 5
    .Services //PASO 5
    .AddDbContext<PeruDbContext> //PASO 5
    (options => options.UseSqlServer(_cnx)); //PASO 5

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
