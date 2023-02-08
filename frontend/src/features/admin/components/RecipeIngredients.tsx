
const RecipeIngredients = (props : any) => {
    return (
        <ul>
        {
            props.ingredients.map((ing : any) => (
                <li key={ing.id}>{`${ing.amount}${ing.ingredient.unitOfMeasure} ${ing.ingredient.name}`}</li>
            ))
        }
        </ul>
    )
}

export default RecipeIngredients