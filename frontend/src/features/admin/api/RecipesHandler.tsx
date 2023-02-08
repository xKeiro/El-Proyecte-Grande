import axios from "axios";

export async function getRecipes() {
     const res = await axios.get(`https://localhost:44329/api/Recipes`);
     res.data.sort((n1: { name: string; }, n2: { name: string; }) => {
          if (n1.name > n2.name) {
               return 1;
          }
          if (n1.name < n2.name) {
               return -1;
          }
          return 0;
     })
     return res.data
}

export async function deleteRecipeById(id : number) {
     await axios.delete(`https://localhost:44329/api/Recipes/${id}`)
}