using AutoMapper;
using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Dtos.Categories.Diet;
using ElProyecteGrande.Dtos.Categories.DishType;
using ElProyecteGrande.Dtos.Categories.MealTime;
using ElProyecteGrande.Dtos.Ingredient;
using ElProyecteGrande.Dtos.Recipes.Recipe;
using ElProyecteGrande.Dtos.Recipes.RecipeIngredient;
using ElProyecteGrande.Dtos.Recipes.RecipeReview;
using ElProyecteGrande.Dtos.Users.User;
using ElProyecteGrande.Dtos.Users.UserRecipe;
using ElProyecteGrande.Dtos.Users.UserRecipeStatus;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models.Recipes;
using ElProyecteGrande.Models.Users;

namespace ElProyecteGrande.Maps;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        _ = CreateMap<Cuisine, CuisinePublic>();
        _ = CreateMap<CuisinePublic, Cuisine>();
        _ = CreateMap<Cuisine, CuisineWithoutId>();
        _ = CreateMap<CuisineWithoutId, Cuisine>();

        _ = CreateMap<Diet, DietPublic>();
        _ = CreateMap<DietPublic, Diet>();
        _ = CreateMap<Diet, DietWithoutId>();
        _ = CreateMap<DietWithoutId, Diet>();

        _ = CreateMap<DishType, DishTypePublic>();
        _ = CreateMap<DishTypePublic, DishType>();
        _ = CreateMap<DishType, DishTypeWithoutId>();
        _ = CreateMap<DishTypeWithoutId, DishType>();

        _ = CreateMap<MealTime, MealTimePublic>();
        _ = CreateMap<MealTimePublic, MealTime>();
        _ = CreateMap<MealTime, MealTimeWithoutId>();
        _ = CreateMap<MealTimeWithoutId, MealTime>();

        _ = CreateMap<Ingredient, IngredientPublic>();
        _ = CreateMap<IngredientPublic, Ingredient>();
        _ = CreateMap<Ingredient, IngredientWithoutId>();
        _ = CreateMap<IngredientWithoutId, Ingredient>();

        _ = CreateMap<Recipe, RecipePublic>();
        _ = CreateMap<RecipePublic, Recipe>();
        _ = CreateMap<Recipe, RecipeWithoutId>();
        _ = CreateMap<RecipeWithoutId, Recipe>();

        _ = CreateMap<RecipeIngredient, RecipeIngredientPublic>();
        _ = CreateMap<RecipeIngredientPublic, RecipeIngredient>();
        _ = CreateMap<RecipeIngredient, RecipeIngredientWithoutId>();
        _ = CreateMap<RecipeIngredientWithoutId, RecipeIngredient>();

        _ = CreateMap<RecipeReview, RecipeReviewPublic>();
        _ = CreateMap<RecipeReviewPublic, RecipeReview>();
        _ = CreateMap<RecipeReview, RecipeReviewWithoutId>();
        _ = CreateMap<RecipeReviewWithoutId, RecipeReview>();

        _ = CreateMap<User, UserPublic>();
        _ = CreateMap<UserPublic, User>();
        _ = CreateMap<User, UserWithoutId>();
        _ = CreateMap<UserWithoutId, User>();

        _ = CreateMap<UserRecipe, UserRecipePublic>();
        _ = CreateMap<UserRecipePublic, UserRecipe>();
        _ = CreateMap<UserRecipe, UserRecipeWithoutId>();
        _ = CreateMap<UserRecipeWithoutId, UserRecipe>();

        _ = CreateMap<UserRecipeStatus, UserRecipeStatusPublic>();
        _ = CreateMap<UserRecipeStatusPublic, UserRecipeStatus>();
        _ = CreateMap<UserRecipeStatus, UserRecipeStatusWithoutId>();
        _ = CreateMap<UserRecipeStatusWithoutId, UserRecipeStatus>();
    }
}