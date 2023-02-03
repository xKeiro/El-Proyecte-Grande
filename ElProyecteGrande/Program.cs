using ElProyecteGrande.Services;
using Microsoft.EntityFrameworkCore;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models;
using ElProyecteGrande.Services.Categories;
using ElProyecteGrande.Data;
using System.Text.Json.Serialization;
using ElProyecteGrande.Models.Users;
//using ElProyecteGrande.Services.Users;
using ElProyecteGrande.Models.Recipes;
using ElProyecteGrande.Maps;
using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Dtos.Categories.Diet;
using ElProyecteGrande.Dtos.Categories.MealTime;
using ElProyecteGrande.Dtos.Ingredient;
using ElProyecteGrande.Dtos.Categories.DishType;
using ElProyecteGrande.Dtos.Recipes.Recipe;
using ElProyecteGrande.Dtos.Users.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<ElProyecteGrandeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ElProyecteGrandeContext")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Services
builder.Services.AddScoped<IBasicCrudService<MealTimePublic, MealTimeWithoutId>, MealTimeService>();
builder.Services.AddScoped<IStatusMessageService<MealTime>, StatusMessageService<MealTime>>();

builder.Services.AddScoped<IBasicCrudService<DishTypePublic, DishTypeWithoutId>, DishTypeService>();
builder.Services.AddScoped<IStatusMessageService<DishType>, StatusMessageService<DishType>>();

builder.Services.AddScoped<ICuisineService, CuisineService>();
builder.Services.AddScoped<IStatusMessageService<Cuisine>, StatusMessageService<Cuisine>>();

builder.Services.AddScoped<IBasicCrudService<IngredientPublic, IngredientWithoutId>, IngredientService>();
builder.Services.AddScoped<IStatusMessageService<Ingredient>, StatusMessageService<Ingredient>>();

builder.Services.AddScoped<IBasicCrudService<DietPublic, DietWithoutId>, DietService>();
builder.Services.AddScoped<IStatusMessageService<Diet>, StatusMessageService<Diet>>();

//builder.Services.AddScoped<IBasicCrudService<UserRecipe>, UserRecipeService>();
//builder.Services.AddScoped<IStatusMessageService<UserRecipe>, StatusMessageService<UserRecipe>>();

builder.Services.AddScoped<IUserService<UserPublic, UserWithoutId>, UserService>();
builder.Services.AddScoped<IStatusMessageService<User>, StatusMessageService<User>>();

builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IStatusMessageService<Recipe>, StatusMessageService<Recipe>>();

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
