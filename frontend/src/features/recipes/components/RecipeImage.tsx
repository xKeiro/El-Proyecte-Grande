
export const RecipeImage = (props: { id: number, name : string }) => {
    let path = "/src/assets/images/recipes/";
    return (
        <img className="rounded-lg" src={path + props.id + ".jpg"} alt={props.name} title={props.name} width={400} height={500}/>
    )
}