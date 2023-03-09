import { TRecipe } from "@/features/recipes";
import { RecipeUserButtons } from "@/features/recipes/components/RecipeUserButtons";

export const RecipeHeader = ({ recipe, username } : {recipe : TRecipe | null, username : string | null }) => {
    if(!recipe){
        return null
    }
    return (
        <div className="recipe-header mb-5">
            <div className="recipe-name font-bold text-2xl mb-2 mb-5 italic flex flex-row gap-2">
                <span>{recipe.name}</span>
                -
                <span className="text-primary">{recipe.difficulty}</span>
                {
                    username != null && <RecipeUserButtons />
                }
            </div>
            <div className="badges">
                <div className="badge badge-accent font-bold italic">{recipe.cuisine.name}</div>
                <div className="badge badge-accent font-bold italic ml-2">{recipe.dishType.name}</div>
                {
                    recipe.diets.map((diet) => (
                        <div key={diet.id} className="badge badge-accent font-bold italic ml-2">{diet.name}</div>
                    ))
                }
                {
                    recipe.mealTimes.map((mealTime) => (
                        <div key={mealTime.id} className="badge badge-accent font-bold italic ml-2">{mealTime.name}</div>
                    ))
                }
            </div>
        </div>
    )
}