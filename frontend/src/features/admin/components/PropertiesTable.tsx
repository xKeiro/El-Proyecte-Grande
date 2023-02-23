import {Category} from "@/features/categories";
import {Ingredient} from "@/features/ingredients";

export const PropertiesTable = (props : {categories : Category[], ingredients : Ingredient[]}) => {
    return (
        <table className="table table-zebra w-5/12">
            <thead>
            <tr>
                <th>Name</th>
                { props.ingredients.length > 0 && <th>Unit of Measure</th> }
                { props.ingredients.length > 0 && <th>Calorie</th> }
                <th></th>
            </tr>
            </thead>
            <tbody>
            { props.categories.length > 0 ?
                props.categories.map(cat => (
                <tr key={cat.id}>
                    <td>{cat.name}</td>
                    <td></td>
                </tr>
            )) :
                props.ingredients.map(ing => (
                    <tr key={ing.id}>
                        <td>{ing.name}</td>
                        <td>{ing.unitOfMeasure}</td>
                        <td>{ing.calorie}</td>
                        <td></td>
                    </tr>
                ))
            }
            </tbody>
        </table>
    );
}