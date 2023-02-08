import {useLocation} from "react-router-dom";
import RecipeHeader from "./RecipeHeader";
import RecipeImage from "./RecipeImage";
import RecipeDescription from "./RecipeDescription";
import RecipeIngredients from "./RecipeIngredients";
import RecipePreparation from "@/features/admin/components/RecipePreparation";
import {RecipeButtons} from "@/features/admin/components/RecipeButtons";

const Recipe = () => {
    let recipe = useLocation().state
    console.log(recipe)
    return (
        <div className="card shadow-xl">
            <div className="card card-side bg-base-100">
                <RecipeImage />
                <div className="card-body recipe-info">
                    <RecipeHeader name={recipe.name} cuisine={recipe.cuisine} dishType={recipe.dishType} diets={recipe.diets} mealTimes={recipe.mealTimes} />
                    <RecipeDescription description={recipe.description} />
                    <h3 className="recipe-sub-title">Ingredients</h3>
                    <RecipeIngredients ingredients={recipe.recipeIngredients} />
                </div>
            </div>
            <RecipePreparation />
            <RecipeButtons recipeId={recipe.id} />
        </div>
    )
}

export default Recipe