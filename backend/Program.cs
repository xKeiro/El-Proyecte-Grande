using ElProyecteGrande.Data;
using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Dtos.Categories.Diet;
using ElProyecteGrande.Dtos.Categories.DishType;
using ElProyecteGrande.Dtos.Categories.MealTime;
using ElProyecteGrande.Dtos.Ingredient;
using ElProyecteGrande.Dtos.Users.User;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Maps;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models.Recipes;
using ElProyecteGrande.Models.Users;
using ElProyecteGrande.Services;
using ElProyecteGrande.Services.Categories;
using ElProyecteGrande.Services.Users;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("http://localhost:5173")
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

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
builder.Services.AddScoped<ICategoryService<MealTimePublic, MealTimeWithoutId>, MealTimeService>();
builder.Services.AddScoped<IStatusMessageService<MealTime>, StatusMessageService<MealTime>>();

builder.Services.AddScoped<ICategoryService<DishTypePublic, DishTypeWithoutId>, DishTypeService>();
builder.Services.AddScoped<IStatusMessageService<DishType>, StatusMessageService<DishType>>();

builder.Services.AddScoped<ICategoryService<CuisinePublic, CuisineWithoutId>, CuisineService>();
builder.Services.AddScoped<IStatusMessageService<Cuisine>, StatusMessageService<Cuisine>>();

builder.Services.AddScoped<IBasicCrudService<IngredientPublic, IngredientWithoutId>, IngredientService>();
builder.Services.AddScoped<IStatusMessageService<Ingredient>, StatusMessageService<Ingredient>>();

builder.Services.AddScoped<ICategoryService<DietPublic, DietWithoutId>, DietService>();
builder.Services.AddScoped<IStatusMessageService<Diet>, StatusMessageService<Diet>>();

// builder.Services.AddScoped<IBasicCrudService<UserRecipe>, UserRecipeService>();
// builder.Services.AddScoped<IStatusMessageService<UserRecipe>, StatusMessageService<UserRecipe>>();
builder.Services.AddScoped<IUserService<UserPublic, UserWithoutId>, UserService>();
builder.Services.AddScoped<IStatusMessageService<User>, StatusMessageService<User>>();

builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IStatusMessageService<Recipe>, StatusMessageService<Recipe>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corspolicy");

app.UseAuthorization();

app.MapControllers();

// Seed the DB with initial data
AppDbInitializer.Seed(app);

app.Run();