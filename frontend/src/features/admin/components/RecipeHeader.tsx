
const RecipeHeader = (props : any) => {
    return (
        <div className="recipe-header">
            <div className="recipe-name">{props.name}</div>
            <div className="badges">
                <div className="badge badge-accent">{props.cuisine.name}</div>
                <div className="badge badge-accent">{props.dishType.name}</div>
                {
                    props.diets.map((d : any) => (
                        <div key={d.id} className="badge badge-accent">{d.name}</div>
                    ))
                }
                {
                    props.mealTimes.map((m : any) => (
                        <div key={m.id} className="badge badge-accent">{m.name}</div>
                    ))
                }
            </div>
        </div>
    )
}

export default RecipeHeader