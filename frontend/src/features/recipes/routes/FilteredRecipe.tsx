import { RecipeImage } from "../components/RecipeImage";
import { RecipeHeader } from "../components/RecipeHeader";
import { RecipeDescription } from "../components/RecipeDescription";
import { RecipeIngredients } from "../components/RecipeIngredients";
import { RecipePreparation } from "../components/RecipePreparation";
import { RecipeButtons } from "../components/RecipeButtons";
import { TRecipe } from "../types";

export const FilteredRecipe = ({ recipes }: { recipes: TRecipe[] }) => {

    if (!recipes) return (<div>Loading...</div>);
    console.log(recipes)
    return (
      <div>
        {recipes.map(recipe => (
          <div key={recipe.id}>
            <div >
              <RecipeImage id={recipe.id} name={recipe.name} />
              <div className="card-body recipe-info">
                <RecipeHeader recipe={recipe} />
                <RecipeDescription description={recipe.description} />
                <h3 >Ingredients</h3>
                <RecipeIngredients ingredients={recipe.recipeIngredients} />
              </div>
            </div>
            <RecipePreparation preparationSteps={recipe.preparationSteps} />
            <RecipeButtons recipeId={recipe.id} />
          </div>
        ))}
      </div>
    );
  };
