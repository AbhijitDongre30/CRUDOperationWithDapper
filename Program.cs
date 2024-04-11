using CRUDOperationWithDapper.Interfaces;
using CRUDOperationWithDapper.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IDbServices, DbServices>();
builder.Services.AddScoped<IEmployee, EmployeeDAL>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
