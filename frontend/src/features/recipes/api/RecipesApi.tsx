import axios from 'axios';
import { API_URL } from '@/config';
import { recipesSchemaWithPagination, recipeSchema, TRecipesFilter } from '@/features/recipes';
import { TRecipesWithPagination } from '@/features/recipes';
import {TRecipe} from '@/features/recipes';

export abstract class RecipesApi {
  public static async getAll() : Promise<TRecipesWithPagination | null> {
    const res = await axios.get(`${API_URL}/Recipes`, { withCredentials : true });
    const result = recipesSchemaWithPagination.safeParse(res.data);

    if (result.success) {
      return res.data;
    } else {
      console.log(result.error.issues);
      return null;
    }
  }

  public static async getLastRecipe(){
    const res = await axios.get(`${API_URL}/Recipes/Last`, { withCredentials: true });
    const result = recipeSchema.safeParse(res.data);
    console.log(result)
    if (result.success) {
      return res.data;
    } else {
      console.log(result.error.issues);
    }
  }

  public static async get(id: number) {
    const res = await axios.get(`${API_URL}/Recipes/${id}`, { withCredentials : true });
    const result = recipeSchema.safeParse(res.data);
    if (result.success) {
      return res.data;
    } else {
      console.log(result.error.issues);
    }
  }

  public static async deleteById(id: number) {
    await axios.delete(`${API_URL}/Recipes/${id}`, { withCredentials : true });
  }

  public static constructRecipesFilterUrl(filter: TRecipesFilter): string {
    const ingredientParams = filter.ingredientIds.length > 0 ? "&" + filter.ingredientIds.map(id => `IngredientIds=${id}`).join('&') : '';
    const cuisineParams = filter.cuisineIds.length > 0 ? "&" + filter.cuisineIds.map(id => `CuisineIds=${id}`).join('&') : '';
    const dietParams = filter.dietIds.length > 0 ? "&" + filter.dietIds.map(id => `DietIds=${id}`).join('&') : '';
    const mealTimeParams = filter.mealTimeIds.length > 0 ? "&" + filter.mealTimeIds.map(id => `MealTimeIds=${id}`).join('&') : '';
    const dishTypeParams = filter.dishTypeIds.length > 0 ? "&" + filter.dishTypeIds.map(id => `DishTypeIds=${id}`).join('&') : '';
    const nameParam = filter.searchString.length > 0 ? `&Name=${filter.searchString}` : '';
    const preparationMaxDifficultyParam = filter.preparationMaxDifficulty ? `&MaxDifficulty=${filter.preparationMaxDifficulty}` : '';
    const maxNumberOfNotOwnedIngredientsParam = filter.maxNotOwnedIngredients > 0 ? `&MaxNumberOfNotOwnedIngredients=${filter.maxNotOwnedIngredients}` : '';
    const recipesPerPageParam = `&RecipesPerPage=${filter.recipesPerPage}`
    return `${API_URL}/Recipes/Page/${filter.page}?${nameParam}${ingredientParams}${cuisineParams}${mealTimeParams}${dietParams}${dishTypeParams}${preparationMaxDifficultyParam}${maxNumberOfNotOwnedIngredientsParam}${recipesPerPageParam}`;
  }

  public static async filterRecipes(filter:TRecipesFilter): Promise<TRecipesWithPagination | null> {
    const apiUrl = RecipesApi.constructRecipesFilterUrl(filter);
    const response = await axios.get(apiUrl, { withCredentials : true });
    const result = recipesSchemaWithPagination.safeParse(response.data);
    if (result.success) {
      return response.data;
    } else {
      console.log(result.error.issues);
      return null
    }
  }

  public static async filterRecipesByUrl(apiUrl:string): Promise<TRecipesWithPagination | null> {
    const response = await axios.get(apiUrl, { withCredentials : true });
    const result = recipesSchemaWithPagination.safeParse(response.data);
    if (result.success) {
      return response.data;
    } else {
      console.log(result.error.issues);
      return null
    }
  }

}
