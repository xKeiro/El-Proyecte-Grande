import {Recipe} from "@/features/recipes";

const RecipeHeader = (props : {recipe : Recipe}) => {
    const recipe = props.recipe
    return (
        <div className="recipe-header">
            <div className="recipe-name">{recipe.name}</div>
            <div className="badges">
                <div className="badge badge-accent">{recipe.cuisine.name}</div>
                <div className="badge badge-accent">{recipe.dishType.name}</div>
                {
                    recipe.diets.map((diet) => (
                        <div key={diet.id} className="badge badge-accent">{diet.name}</div>
                    ))
                }
                {
                    recipe.mealTimes.map((mealTime) => (
                        <div key={mealTime.id} className="badge badge-accent">{mealTime.name}</div>
                    ))
                }
            </div>
        </div>
    )
}

export default RecipeHeader