using ElProyecteGrande.Services;
using ElProyecteGrande.Services.Category;
using Microsoft.EntityFrameworkCore;
using ElProyecteGrande.Controllers;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ElProyecteGrandeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ElProyecteGrandeContext")));
builder.Services.AddScoped<IBasicCrudService<Cuisine>, CuisineService>();
builder.Services.AddScoped<IBasicCrudService<Ingredient>, IngredientService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Services
builder.Services.AddScoped<IMealTimeService, MealTimeService>();
builder.Services.AddScoped<IDishTypeService, DishTypeService>();

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
