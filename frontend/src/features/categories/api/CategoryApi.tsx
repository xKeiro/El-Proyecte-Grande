import axios from 'axios';
import { API_URL } from '@/config';
import {categoriesSchema, CategoriesEnum, categorySchema} from '../types';

export abstract class CategoryApi {
  public static async getAll(category: CategoriesEnum) {
    const res = await axios.get(`${API_URL}/${category}`, { withCredentials : true });
    const result = categoriesSchema.safeParse(res.data);

    if (result.success) {
      return res.data;
    } else {
      console.log(result.error.issues);
    }
  }

  public static async deleteById(id: number, category: CategoriesEnum) {
    await axios.delete(`${API_URL}/${category}/${id}`, { withCredentials : true });
  }

  public static async add(category: CategoriesEnum, name : string) {
    let errorMsg = "";
    const resp = await axios.post(`${API_URL}/${category}`, {
      name: name,
    }, { withCredentials : true }).catch((error) => {
      errorMsg = error.response.data.message;
    });
    if (errorMsg) return errorMsg;

    const result = categorySchema.safeParse(resp?.data);

    if (result.success) {
      return resp?.data;
    } else {
      console.log(result.error.issues);
    }
  }
}
