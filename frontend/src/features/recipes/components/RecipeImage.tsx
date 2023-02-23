
export const RecipeImage = (props: { id: number, name : string, size?: { width: number, height: number } }) => {
    let path = "/src/assets/images/recipes/";
    let { width, height } = props.size || { width: 400, height: 500 };
    return (
        <img className="rounded-lg" src={path + props.id + ".jpg"} alt={props.name} title={props.name} width={width} height={height}/>
    )
}