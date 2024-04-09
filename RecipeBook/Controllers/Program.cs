using DatasetAPI;
using Microsoft.EntityFrameworkCore;
using Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<RecipeServices>();

builder.Services.AddScoped<UserLoginService>();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(
        "Server=localhost;Port=5432;User Id=postgres;Password=ishajain;Database=IshaDb;Pooling=true;");
});
var app = builder.Build();
app.UseCors(options => options
.AllowAnyOrigin().
AllowAnyMethod().
AllowAnyHeader());
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
