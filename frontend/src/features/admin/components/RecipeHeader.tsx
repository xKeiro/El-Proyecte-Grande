import {TRecipe} from "@/features/recipes";

const RecipeHeader = (props : {recipe : TRecipe | null}) => {
    const recipe = props.recipe
    if(!recipe){
        return null
    }
    return (
        <div className="recipe-header mb-5">
            <div className="recipe-name font-bold text-2xl mb-2 mb-5 italic">{recipe.name}</div>
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

export default RecipeHeader