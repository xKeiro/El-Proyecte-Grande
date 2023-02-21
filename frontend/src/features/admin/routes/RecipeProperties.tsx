
export const RecipeProperties = () => {
    return (
        <div className="card shadow-xl">
            <div className="card card-side bg-base-100">
                <div className="card-body items-center flex gap-5">
                    <button className="btn btn-md bg-primary border-0 w-2/4 text-xl">Cuisines</button>
                    <button className="btn btn-md border-0 w-2/4 text-xl">Meal Times</button>
                    <button className="btn btn-md border-0 w-2/4 text-xl">Diets</button>
                    <button className="btn btn-md border-0 w-2/4 text-xl">Dish Types</button>
                    <button className="btn btn-md border-0 w-2/4 text-xl">Ingredients</button>
                </div>
                <div className="card-body">
                    <table className="table w-full">
                        <thead>
                        <tr>
                            <th>Name</th>
                            <th></th>
                        </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>ASD</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>ASD</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>ASD</td>
                                <td></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}