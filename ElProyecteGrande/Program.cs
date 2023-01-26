using ElProyecteGrande.Services;
using Microsoft.EntityFrameworkCore;
using ElProyecteGrande.Controllers;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models;
using ElProyecteGrande.Services.Categories;
using ElProyecteGrande.Data;
using System.Text.Json.Serialization;
using ElProyecteGrande.Models.Users;
using ElProyecteGrande.Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ElProyecteGrandeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ElProyecteGrandeContext")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Services
builder.Services.AddScoped<IBasicCrudService<MealTime>, MealTimeService>();
builder.Services.AddScoped<IStatusMessageService<MealTime>, StatusMessageService<MealTime>>();

builder.Services.AddScoped<IBasicCrudService<DishType>, DishTypeService>();
builder.Services.AddScoped<IStatusMessageService<DishType>, StatusMessageService<DishType>>();

builder.Services.AddScoped<IBasicCrudService<Cuisine>, CuisineService>();
builder.Services.AddScoped<IStatusMessageService<Cuisine>, StatusMessageService<Cuisine>>();

builder.Services.AddScoped<IBasicCrudService<Ingredient>, IngredientService>();
builder.Services.AddScoped<IStatusMessageService<Ingredient>, StatusMessageService<Ingredient>>();

builder.Services.AddScoped<IBasicCrudService<Diet>, DietService>();
builder.Services.AddScoped<IStatusMessageService<Diet>, StatusMessageService<Diet>>();

builder.Services.AddScoped<IBasicCrudService<UserRecipe>, UserRecipeService>();
builder.Services.AddScoped<IStatusMessageService<UserRecipe>, StatusMessageService<UserRecipe>>();

builder.Services.AddScoped<IBasicCrudService<User>, UserService>();
builder.Services.AddScoped<IStatusMessageService<User>, StatusMessageService<User>>();

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

// Seed the DB with initial data
AppDbInitializer.Seed(app);

app.Run();
