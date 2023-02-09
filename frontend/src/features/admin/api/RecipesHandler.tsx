import axios from "axios";
import {recipesSchema} from "@/features/recipes";

export async function getRecipes() {
     const res = await axios.get(`https://localhost:44329/api/Recipes`);
     const result = recipesSchema.safeParse(res.data);

     if (result.success) {
          return res.data
     }
     else {
          console.log(result.error.issues)
     }
}

export async function deleteRecipeById(id : number) {
     await axios.delete(`https://localhost:44329/api/Recipes/${id}`)
}