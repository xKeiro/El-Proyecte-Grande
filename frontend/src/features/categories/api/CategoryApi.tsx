import axios from 'axios';
import { API_URL } from '@/config';
import { categoriesSchema, CategoriesEnum } from '../types';

export abstract class CategoryApi {
  public static async getAll(category: CategoriesEnum) {
    const res = await axios.get(`${API_URL}/${category}`);
    const result = categoriesSchema.safeParse(res.data);

    if (result.success) {
      return res.data;
    } else {
      console.log(result.error.issues);
    }
  }

  public static async deleteById(id: number, category: CategoriesEnum) {
    await axios.delete(`${API_URL}/${category}/${id}`);
  }
}
