import axios from "axios";
import { API_URL } from "@/config";
import {recipesSchema} from "@/features/recipes";

export async function getRecipes() {
     const res = await axios.get(`${API_URL}/Recipes`);
     const result = recipesSchema.safeParse(res.data);

     if (result.success) {
          return res.data
     }
     else {
          console.log(result.error.issues)
     }
}

export async function deleteRecipeById(id : number) {
     await axios.delete(`${API_URL}/Recipes/${id}`)
}