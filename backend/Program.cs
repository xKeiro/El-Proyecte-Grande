using System.Configuration;
using System.Net;
using System.Text;
using backend.Data;
using backend.Dtos.Categories.Cuisine;
using backend.Dtos.Categories.Diet;
using backend.Dtos.Categories.DishType;
using backend.Dtos.Categories.MealTime;
using backend.Dtos.Ingredient;
using backend.Dtos.Users.User;
using backend.Interfaces.Services;
using backend.Maps;
using backend.Models;
using backend.Models.Categories;
using backend.Models.Recipes;
using backend.Models.Users;
using backend.Services;
using backend.Services.Categories;
using backend.Services.Users;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using backend.Dtos.Recipes.PreparationStep;
using backend.Utils;


DotNetEnv.Env.Load();
var builder = WebApplication.CreateBuilder(args);

// Add environment variables

builder.Services.AddCors(p => p.AddPolicy("corspolicy",
    builder => builder.WithOrigins(EnvironmentVariableHelper.FrontendUrl)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        ));

// Add services to the container.
builder.Services.AddOutputCache();
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddHealthChecks();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(typeof(MappingProfile));



builder.Services.AddDbContext<ElProyecteGrandeContext>(options =>
    options.UseSqlServer(EnvironmentVariableHelper.ConnectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Authentication
var key = Encoding.ASCII.GetBytes(EnvironmentVariableHelper.JwtTokenKey);
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.SaveToken = true;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
    opt.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.Request.Cookies["jwt"];
            return Task.CompletedTask;
        }
    };
});
//.AddGoogle(options =>
//{
//    IConfigurationSection googleAuthNSection = builder.Configuration.GetSection("Authentication:Google");

//    options.ClientId = googleAuthNSection["ClientId"];
//    options.ClientSecret = googleAuthNSection["ClientSecret"];

//    if (options.ClientId is null || options.ClientSecret is null) throw new ConfigurationErrorsException("Missing Google secrets!");
//});

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

builder.Services.AddScoped<IBasicCrudService<PreparationStepPublic, PreparationStepWithoutId>, PreparationStepService>();
builder.Services.AddScoped<IStatusMessageService<PreparationStep>, StatusMessageService<PreparationStep>>();

// builder.Services.AddScoped<IBasicCrudService<UserRecipe>, UserRecipeService>();
// builder.Services.AddScoped<IStatusMessageService<UserRecipe>, StatusMessageService<UserRecipe>>();
builder.Services.AddScoped<IUserService<UserPublic, UserWithoutId>, UserService>();
builder.Services.AddScoped<IStatusMessageService<User>, StatusMessageService<User>>();

builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IStatusMessageService<Recipe>, StatusMessageService<Recipe>>();

builder.Services.AddScoped<IAuthService, AuthService>();


var app = builder.Build();
app.MapHealthChecks("/api/HealthChecker");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseCors("corspolicy");

app.UseAuthentication();
app.UseAuthorization();
app.UseOutputCache();

app.MapControllers();

// Seed the DB with initial data
AppDbInitializer.Seed(app);

app.Run();

