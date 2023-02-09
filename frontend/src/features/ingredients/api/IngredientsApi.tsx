import axios from 'axios';
import { API_URL } from '@/config';
import { ingredientsSchema } from '../types';

export abstract class IngredientsApi {
  public static async getAll() {
    const res = await axios.get(`${API_URL}/Ingredients`);
    const result = ingredientsSchema.safeParse(res.data);

    if (result.success) {
      return res.data;
    } else {
      console.log(result.error.issues);
    }
  }

  public static async deleteById(id: number) {
    await axios.delete(`${API_URL}/Ingredients/${id}`);
  }
}
