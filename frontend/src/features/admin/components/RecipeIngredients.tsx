
const RecipeIngredients = (props : any) => {
    return (
        <div className="grid grid-cols-5">
            {
                props.ingredients.map((ing : any) => (
                    <li key={ing.id}>{`${ing.amount}${ing.ingredient.unitOfMeasure} ${ing.ingredient.name}`}</li>
                ))
            }
        </div>
    )
}

export default RecipeIngredients