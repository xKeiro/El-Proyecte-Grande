import {RecipeIngredient} from "@/features/recipes";

const RecipeIngredients = (props : {ingredients : RecipeIngredient[]}) => {
    const longUnitOfMeasures = ["bunch", "piece"]
    return (
        <div className="recipe-info grid grid-cols-3">
            <ul>
                {
                    props.ingredients.map((ing : RecipeIngredient) => (
                        <li key={ing.id}>
                            <b>
                                {ing.amount}
                                {longUnitOfMeasures.includes(ing.ingredient.unitOfMeasure) ? " " : ""}
                                {ing.ingredient.unitOfMeasure}
                            </b> <span className="text-info">{ing.ingredient.name}</span>
                        </li>
                    ))
                }
            </ul>
        </div>
    )
}

export default RecipeIngredients