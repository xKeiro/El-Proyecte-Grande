using AutoMapper;
using backend.Dtos.Categories.Cuisine;
using backend.Dtos.Categories.Diet;
using backend.Dtos.Categories.DishType;
using backend.Dtos.Categories.MealTime;
using backend.Dtos.Ingredient;
using backend.Dtos.PreparationStep;
using backend.Dtos.Recipes.Recipe;
using backend.Dtos.Recipes.RecipeIngredient;
using backend.Dtos.Recipes.RecipeReview;
using backend.Dtos.Users.User;
using backend.Dtos.Users.UserRecipe;
using backend.Dtos.Users.UserRecipeStatus;
using backend.Models;
using backend.Models.Categories;
using backend.Models.Recipes;
using backend.Models.Users;

namespace backend.Maps;

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

        _ = CreateMap<PreparationStepPublic, PreparationStep>();
        _ = CreateMap<PreparationStep, PreparationStepPublic>();
        _ = CreateMap<PreparationStepWithoutId, PreparationStep>();
        _ = CreateMap<PreparationStep, PreparationStepWithoutId>();
    }
}