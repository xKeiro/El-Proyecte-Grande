import axios from 'axios';
import { API_URL } from '@/config';
import {ingredientSchema, ingredientsSchema} from '../types';

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

  public static async add(name : string, unitOfMeasure : string, calorie : number) {
    let errorMsg = "";
    const resp = await axios.post(`${API_URL}/Ingredients`, {
      name: name,
      unitOfMeasure: unitOfMeasure,
      calorie: calorie
    }).catch((error) => {
      errorMsg = error.response.data.message;
    });
    if (errorMsg) return errorMsg;

    const result = ingredientSchema.safeParse(resp?.data);

    if (result.success) {
      return resp?.data;
    } else {
      console.log(result.error.issues);
    }
  }
}
