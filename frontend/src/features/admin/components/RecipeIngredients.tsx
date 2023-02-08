
const RecipeIngredients = (props : any) => {
    return (
        <div className="recipe-info grid grid-cols-3">
            <ul>
                {
                    props.ingredients.map((ing : any) => (
                        <li key={ing.id}><b><i>{ing.amount + ing.ingredient.unitOfMeasure}</i></b> - {ing.ingredient.name}</li>
                    ))
                }
            </ul>
        </div>
    )
}

export default RecipeIngredients