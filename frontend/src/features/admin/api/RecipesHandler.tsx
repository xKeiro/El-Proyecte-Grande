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
     // let testItems = [
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Cen with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roost Chicken with Salad"},
     //     {"name": "Chicken with Salad"},
     //     {"name": "With Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     //     {"name": "Roast Chicken with Salad"},
     // ]
     // testItems.sort((n1, n2) => {
     //      if (n1.name > n2.name) {
     //           return 1;
     //      }
     //      if (n1.name < n2.name) {
     //           return -1;
     //      }
     //      return 0;
     // })
     // return testItems
}