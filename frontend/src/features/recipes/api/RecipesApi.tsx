import axios from 'axios';
import { API_URL } from '@/config';
import { recipesSchema, recipeSchema } from '@/features/recipes';

export abstract class RecipesApi {
  public static async getAll(){
    const res = await axios.get(`${API_URL}/Recipes`);
    const result = recipesSchema.safeParse(res.data);

    if (result.success) {
      return res.data;
    } else {
      console.log(result.error.issues);
    }
  }

  public static async get(id : number) {
    const res = await axios.get(`${API_URL}/Recipes/${id}`);
    print(res.data)
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
}
