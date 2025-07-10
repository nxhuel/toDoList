using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using task_list_api.Configurations;
using task_list_api.Context;
using task_list_api.Mappings;
using task_list_api.Services;
using task_list_api.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Var para la cadena de conexion en appsettings.json
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddScoped<ITaskService, TaskServiceImpl>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCorsPolicy();

builder.Services.AddAuthentication();

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Limit API
builder.Services.AddRateLimiter(option =>
{
    option.RejectionStatusCode =
    StatusCodes.Status429TooManyRequests;

    option.AddFixedWindowLimiter("fijo", opt =>
    {
        opt.PermitLimit = 100;
        opt.Window = TimeSpan.FromMinutes(1);
    });
});

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

app.UseRateLimiter();

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowAngularApp");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireRateLimiting("fijo");

app.Run();
