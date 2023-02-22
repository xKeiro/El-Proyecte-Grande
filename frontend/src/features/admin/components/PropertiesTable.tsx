import {Category} from "@/features/categories";

export const PropertiesTable = (props : {categories : Category[]}) => {
    return (
        <table className="table table-zebra w-5/12">
            <thead>
            <tr>
                <th>Name</th>
                <th></th>
            </tr>
            </thead>
            <tbody>
            {props.categories.map(cat => (
                <tr key={cat.id}>
                    <td>{cat.name}</td>
                    <td></td>
                </tr>
            ))}
            </tbody>
        </table>
    );
}