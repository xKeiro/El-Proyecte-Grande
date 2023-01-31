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
        CreateMap<Cuisine, CuisineFull>();
        CreateMap<CuisineFull, Cuisine>();
        CreateMap<Cuisine, CuisineWithoutId>();
        CreateMap<CuisineWithoutId, Cuisine>();
        
        CreateMap<Diet, DietFull>();
        CreateMap<DietFull, Diet>();
        CreateMap<Diet, DietWithoutId>();
        CreateMap<DietWithoutId, Diet>();

        CreateMap<DishType, DishTypeFull>();
        CreateMap<DishTypeFull, DishType>();
        CreateMap<DishType, DishTypeWithoutId>();
        CreateMap<DishTypeWithoutId, DishType>();
        
        CreateMap<MealTime, MealTimeFull>();
        CreateMap<MealTimeFull, MealTime>();
        CreateMap<MealTime, MealTimeWithoutId>();
        CreateMap<MealTimeWithoutId, MealTime>();

        CreateMap<Ingredient, IngredientFull>();
        CreateMap<IngredientFull, Ingredient>();
        CreateMap<Ingredient, IngredientWithoutId>();
        CreateMap<IngredientWithoutId, Ingredient>();

        CreateMap<Recipe, RecipeFull>();
        CreateMap<RecipeFull, Recipe>();
        CreateMap<Recipe, RecipeWithoutId>();
        CreateMap<RecipeWithoutId, Recipe>();

        CreateMap<RecipeIngredient, RecipeIngredientFull>();
        CreateMap<RecipeIngredientFull, RecipeIngredient>();
        CreateMap<RecipeIngredient, RecipeIngredientWithoutId>();
        CreateMap<RecipeIngredientWithoutId, RecipeIngredient>();

        CreateMap<RecipeReview, RecipeReviewFull>();
        CreateMap<RecipeReviewFull, RecipeReview>();
        CreateMap<RecipeReview, RecipeReviewWithoutId>();
        CreateMap<RecipeReviewWithoutId, RecipeReview>();

        CreateMap<User, UserPublic>();
        CreateMap<UserPublic, User>();
        CreateMap<User, UserWithoutId>();
        CreateMap<UserWithoutId, User>();

        CreateMap<UserRecipe, UserRecipeFull>();
        CreateMap<UserRecipeFull, UserRecipe>();
        CreateMap<UserRecipe, UserRecipeWithoutId>();
        CreateMap<UserRecipeWithoutId, UserRecipe>();

        CreateMap<UserRecipeStatus, UserRecipeStatusFull>();
        CreateMap<UserRecipeStatusFull, UserRecipeStatus>();
        CreateMap<UserRecipeStatus, UserRecipeStatusWithoutId>();
        CreateMap<UserRecipeStatusWithoutId, UserRecipeStatus>();

    }
}
