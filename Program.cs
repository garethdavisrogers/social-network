using Microsoft.EntityFrameworkCore;
using SocialNetworkV1.Data;
using SocialNetworkV1.Models;
using SocialNetworkV1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<UserDb>(options => options.UseNpgsql("localhost;Port=5432;Database=userdb;Username=postgres;Password=postgres"));
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserService, UserService>();

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
