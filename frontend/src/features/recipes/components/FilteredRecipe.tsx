import { RecipeImage } from "./RecipeImage";
import { TRecipe } from "../types";
import { Link } from "react-router-dom";

export const FilteredRecipe = ({ recipes }: { recipes: TRecipe[] }) => {
  if (!recipes) return (<div>Loading...</div>);
  if (recipes.length === 0) return (<div className="text-center text-xl">No recipes found, please adjust your filters!</div>);
  return (
    <div className="grid grid-cols-1 lg:grid-cols-2 2xl:grid-cols-3 gap-4 justify-center">
      {recipes.map(recipe => (
        <div key={recipe.id} className="card w-72 md:w-96 bg-base-200 shadow-xl mx-auto">
          <figure className="px-10 pt-10 rounded-x">
            <RecipeImage id={recipe.id} name={recipe.name} size={{ width: 200, height: 250 }} />
          </figure>
          <div className="card-body items-center text-center">
            <h2 className="card-title">{recipe.name}</h2>
            <p>{recipe.description}</p>
            <div className="card-actions">
              <Link to={`/recipes/` + recipe.id}><u>More info...</u></Link>
            </div>
          </div>
        </div>
      ))}
    </div>
  );
};
