import {TRecipeIngredient} from "@/features/recipes";

export const RecipeIngredients = (props : {ingredients : TRecipeIngredient[]}) => {
    const longUnitOfMeasures = ["bunch", "piece"]
    return (
        <div className="recipe-info grid grid-cols-3">
            <ul className="list-disc mt-3 ml-5">
                {
                    props.ingredients.map((ing : TRecipeIngredient) => (
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