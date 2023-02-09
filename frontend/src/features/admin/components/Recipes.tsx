import {getRecipes} from "../api/RecipesHandler";
import {useEffect, useState} from "react";
import {Link} from "react-router-dom";
import {Recipe} from "@/features/recipes";

const Recipes = () => {
  const [recipes, setRecipes] = useState<Recipe[]>([])

   useEffect(() => {
     const fetchData = async () => {
       const result = await getRecipes()
       setRecipes(result)
     }
     fetchData()
    }, [])

    return (
      <div id="recipes-container" className="grid grid-cols-4 gap-5">
          {recipes.map(recipe => (
              <Link key={recipe.id} to={recipe.name} state={recipe}>{recipe.name}</Link>
          ))}
      </div>
    )
}

export default Recipes