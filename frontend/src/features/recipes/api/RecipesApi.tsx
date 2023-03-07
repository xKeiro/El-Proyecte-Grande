import axios from 'axios';
import { API_URL } from '@/config';
import { recipesSchema, recipeSchema } from '@/features/recipes';

export abstract class RecipesApi {
  public static async getAll() {
    const res = await axios.get(`${API_URL}/Recipes`);
    const result = recipesSchema.safeParse(res.data);

    if (result.success) {
      return res.data;
    } else {
      console.log(result.error.issues);
    }
  }

  public static async get(id: number) {
    const res = await axios.get(`${API_URL}/Recipes/${id}`);
    const result = recipeSchema.safeParse(res.data);
    if (result.success) {
      return res.data;
    } else {
      console.log(result.error.issues);
    }
  }

  public static async deleteById(id: number) {
    await axios.delete(`${API_URL}/Recipes/${id}`);
  }

  public static async filterRecipes(cuisineIds: number[], dietIds: number[], mealTimeIds: number[], dishTypeIds: number[], ingredientIds: number[], name: string, maxNumberOfNotOwnedIngredients: number) {
    const ingredientParams = ingredientIds.length > 0 ? ingredientIds.map(id => `IngredientIds=${id}`).join('&') : '';
    const cuisineParams = cuisineIds.length > 0 ? cuisineIds.map(id => `CuisineIds=${id}`).join('&') : '';
    const dietParams = dietIds.length > 0 ? dietIds.map(id => `DietIds=${id}`).join('&') : '';
    const mealTimeParams = mealTimeIds.length > 0 ? mealTimeIds.map(id => `MealTimeIds=${id}`).join('&') : '';
    const dishTypeParams = dishTypeIds.length > 0 ? dishTypeIds.map(id => `DishTypeIds=${id}`).join('&') : '';
    const nameParam = name.length > 0 ? `Name=${name}` : '';
    const maxNumberOfNotOwnedIngredientsParam = maxNumberOfNotOwnedIngredients > 0 ? `MaxNumberOfNotOwnedIngredients=${maxNumberOfNotOwnedIngredients}` : '';
    const apiUrl = `${API_URL}/Recipes?${nameParam}${ingredientParams}&${cuisineParams}&${mealTimeParams}&${dietParams}&${dishTypeParams}${maxNumberOfNotOwnedIngredientsParam}`;
    const response = await axios.get(apiUrl);
    return response.data;
  }

}
