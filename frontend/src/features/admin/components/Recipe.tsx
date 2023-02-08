import {useLocation} from "react-router-dom";

const Recipe = () => {
    let recipe = useLocation().state
    console.log(recipe)
    return (
        <div className="card card-side bg-base-100 shadow-xl">
            <figure><img src="https://upload.wikimedia.org/wikipedia/commons/thumb/6/65/No-Image-Placeholder.svg/1665px-No-Image-Placeholder.svg.png" alt="Movie"/></figure>
            <div className="card-body recipe-body">
                <div className="recipe-header">
                    <div className="recipe-name">{recipe.name}</div>
                    <div className="badges">
                        <div className="badge badge-accent">{recipe.cuisine.name}</div>
                        <div className="badge badge-accent">{recipe.dishType.name}</div>
                        {
                            recipe.diets.map((d : any) => (
                                <div className="badge badge-accent">{d.name}</div>
                            ))
                        }
                        {
                            recipe.mealTimes.map((m : any) => (
                                <div className="badge badge-accent">{m.name}</div>
                            ))
                        }
                    </div>
                </div>
                <p>{recipe.description}</p>

                <h3 className="recipe-sub-title">Ingredients</h3>
                <ul>
                {
                    recipe.recipeIngredients.map((ing : any) => (
                        <li>{`${ing.amount}${ing.ingredient.unitOfMeasure} ${ing.ingredient.name}`}</li>
                    ))
                }
                </ul>
            </div>
        </div>
    )
}

export default Recipe