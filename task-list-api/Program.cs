using Microsoft.EntityFrameworkCore;
using task_list_api.Configurations;
using task_list_api.Context;
using task_list_api.Services;
using task_list_api.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Var para la cadena de conexion en appsettings.json
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddScoped<ITaskService, TaskServieImpl>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCorsPolicy();

builder.Services.AddAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline - Widdleware en orden de solicitud (inversa para respuesta).
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowAngularApp");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
