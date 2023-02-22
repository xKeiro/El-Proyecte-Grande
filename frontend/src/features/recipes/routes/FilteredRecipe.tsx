import { RecipeImage } from "../components/RecipeImage";
import { RecipeHeader } from "../components/RecipeHeader";
import { RecipeDescription } from "../components/RecipeDescription";
import { RecipeIngredients } from "../components/RecipeIngredients";
import { RecipePreparation } from "../components/RecipePreparation";
import { RecipeButtons } from "../components/RecipeButtons";
import { TRecipe } from "../types";
import { Link } from "react-router-dom";

export const FilteredRecipe = ({ recipes }: { recipes: TRecipe[] }) => {
console.log(recipes)
    if (!recipes) return (<div>Loading...</div>);
    return (
      <div>
      <div>
        {recipes.map(recipe => (
          <div key={recipe.id}>
            <div >
              <h1>HII!!</h1>
              <RecipeImage id={recipe.id} name={recipe.name} />
              <div className="card-body recipe-info">
                <RecipeHeader recipe={recipe} />
                <RecipeDescription description={recipe.description} />
                <Link to={`/recipes/` + recipe.id}>More info...</Link>
              </div>
            </div>

          </div>
        ))}
        </div>
      </div>
    );
  };
