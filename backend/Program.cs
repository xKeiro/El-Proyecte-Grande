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

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build => build.WithOrigins("http://localhost:5173")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        ));

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<ElProyecteGrandeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ElProyecteGrandeContext")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Authentication
string? tokenKey = builder.Configuration.GetValue<string>("JwtTokenKey");

if (string.IsNullOrEmpty(tokenKey)) throw new ConfigurationErrorsException("Missing JWT token key!");

var key = Encoding.ASCII.GetBytes(tokenKey);
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseStatusCodePages(async context =>
//{
//    var response = context.HttpContext.Response;
//    string? location = app.Configuration.GetValue<string>("Location");
//    if (string.IsNullOrEmpty(location))
//        throw new ConfigurationErrorsException("Missing location!");

//    if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
//    {
//        response.Redirect(location);
//    }
//});

app.UseCors("corspolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Seed the DB with initial data
AppDbInitializer.Seed(app);

app.Run();