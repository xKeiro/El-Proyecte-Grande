using ElProyecteGrande.Services;
using Microsoft.EntityFrameworkCore;
using ElProyecteGrande.Controllers;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models;
using ElProyecteGrande.Services.Categories;
using ElProyecteGrande.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ElProyecteGrandeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ElProyecteGrandeContext")));
builder.Services.AddScoped<IBasicCrudService<Cuisine>, CuisineService>();
builder.Services.AddScoped<IBasicCrudService<Ingredient>, IngredientService>();
builder.Services.AddScoped<IStatusMessageService<Cuisine>, StatusMessageService<Cuisine>>();
builder.Services.AddScoped<IStatusMessageService<Ingredient>, StatusMessageService<Ingredient>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Services
builder.Services.AddScoped<IBasicCrudService<MealTime>, MealTimeService>();
builder.Services.AddScoped<IStatusMessageService<MealTime>, StatusMessageService<MealTime>>();
builder.Services.AddScoped<IBasicCrudService<DishType>, DishTypeService>();
builder.Services.AddScoped<IStatusMessageService<DishType>, StatusMessageService<DishType>>();

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

AppDbInitializer.Seed(app);

app.Run();
