import {useLocation} from "react-router-dom";
import RecipeHeader from "./RecipeHeader";
import RecipeImage from "./RecipeImage";
import RecipeDescription from "./RecipeDescription";
import RecipeIngredients from "./RecipeIngredients";

const Recipe = () => {
    let recipe = useLocation().state
    console.log(recipe)
    return (
        <div className="card card-side bg-base-100 shadow-xl">
            <RecipeImage />
            <div className="card-body recipe-body">
                <RecipeHeader name={recipe.name} cuisine={recipe.cuisine} dishType={recipe.dishType} diets={recipe.diets} mealTimes={recipe.mealTimes} />
                <RecipeDescription description={recipe.description} />
                <h3 className="recipe-sub-title">Ingredients</h3>
                <RecipeIngredients ingredients={recipe.recipeIngredients} />
            </div>
        </div>
    )
}

export default Recipe