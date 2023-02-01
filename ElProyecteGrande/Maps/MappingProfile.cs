using AutoMapper;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Dtos.Categories.Diet;
using ElProyecteGrande.Dtos.Categories.DishType;
using ElProyecteGrande.Dtos.Categories.MealTime;
using ElProyecteGrande.Models.Recipes;
using ElProyecteGrande.Dtos.Recipes.Recipe;
using ElProyecteGrande.Dtos.Recipes.RecipeIngredient;
using ElProyecteGrande.Dtos.Recipes.RecipeReview;
using ElProyecteGrande.Models.Users;
using ElProyecteGrande.Dtos.Users.User;
using ElProyecteGrande.Dtos.Ingredient;
using ElProyecteGrande.Models;
using ElProyecteGrande.Dtos.Users.UserRecipe;
using ElProyecteGrande.Dtos.Users.UserRecipeStatus;

namespace ElProyecteGrande.Maps;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Cuisine, CuisinePublic>();
        CreateMap<CuisinePublic, Cuisine>();
        CreateMap<Cuisine, CuisineWithoutId>();
        CreateMap<CuisineWithoutId, Cuisine>();
        
        CreateMap<Diet, DietPublic>();
        CreateMap<DietPublic, Diet>();
        CreateMap<Diet, DietWithoutId>();
        CreateMap<DietWithoutId, Diet>();

        CreateMap<DishType, DishTypePublic>();
        CreateMap<DishTypePublic, DishType>();
        CreateMap<DishType, DishTypeWithoutId>();
        CreateMap<DishTypeWithoutId, DishType>();
        
        CreateMap<MealTime, MealTimePublic>();
        CreateMap<MealTimePublic, MealTime>();
        CreateMap<MealTime, MealTimeWithoutId>();
        CreateMap<MealTimeWithoutId, MealTime>();

        CreateMap<Ingredient, IngredientPublic>();
        CreateMap<IngredientPublic, Ingredient>();
        CreateMap<Ingredient, IngredientWithoutId>();
        CreateMap<IngredientWithoutId, Ingredient>();

        CreateMap<Recipe, RecipePublic>();
        CreateMap<RecipePublic, Recipe>();
        CreateMap<Recipe, RecipeWithoutId>();
        CreateMap<RecipeWithoutId, Recipe>();

        CreateMap<RecipeIngredient, RecipeIngredientPublic>();
        CreateMap<RecipeIngredientPublic, RecipeIngredient>();
        CreateMap<RecipeIngredient, RecipeIngredientWithoutId>();
        CreateMap<RecipeIngredientWithoutId, RecipeIngredient>();

        CreateMap<RecipeReview, RecipeReviewPublic>();
        CreateMap<RecipeReviewPublic, RecipeReview>();
        CreateMap<RecipeReview, RecipeReviewWithoutId>();
        CreateMap<RecipeReviewWithoutId, RecipeReview>();

        CreateMap<User, UserPublic>();
        CreateMap<UserPublic, User>();
        CreateMap<User, UserWithoutId>();
        CreateMap<UserWithoutId, User>();

        CreateMap<UserRecipe, UserRecipePublic>();
        CreateMap<UserRecipePublic, UserRecipe>();
        CreateMap<UserRecipe, UserRecipeWithoutId>();
        CreateMap<UserRecipeWithoutId, UserRecipe>();

        CreateMap<UserRecipeStatus, UserRecipeStatusPublic>();
        CreateMap<UserRecipeStatusPublic, UserRecipeStatus>();
        CreateMap<UserRecipeStatus, UserRecipeStatusWithoutId>();
        CreateMap<UserRecipeStatusWithoutId, UserRecipeStatus>();

    }
}
