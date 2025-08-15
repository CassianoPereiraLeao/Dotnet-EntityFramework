using Api.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using Api.Infra.Interfaces;
using Api.Domain.DTOs.Admin;
using Api.OwnedType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

Batteries.Init();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddScoped<IAdminService, AdminService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/login", ([FromBody] AdminRequest adminRequest, IAdminService adminService) =>
{
    var adminDTO = new AdminDTO
    {
        Email = new Email(adminRequest.Email),
        Password = new Password(adminRequest.Password),
        ConfirmPassword = new Password(adminRequest.ConfirmPassword)
    };
    
    Console.WriteLine(adminDTO.Password);

    if (adminService.Login(adminDTO) != null)
    {
        return Results.Ok("Passou no teste de adm");
    }
    return Results.Unauthorized();
});

app.Run();

