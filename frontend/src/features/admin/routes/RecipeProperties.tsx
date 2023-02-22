import {useEffect, useState} from "react";
import {Navigate} from "react-router-dom";
import {CategoryApi} from "@/features/categories/api/CategoryApi";
import {CategoriesEnum, Category} from "@/features/categories";

export const RecipeProperties = () => {
    const [categories, setCategories] = useState<Category[]>([]);

    let isAdmin = true;

    useEffect(() => {
        const fetchData = async () => {
            const result = await CategoryApi.getAll(CategoriesEnum.Cuisines);
            setCategories(result);
        };
        fetchData();
    }, []);

    const showData = (e : any, category : CategoriesEnum) => {
        CategoryApi.getAll(category).then(res => setCategories(res));
        document.getElementsByClassName("active-button")[0].classList.remove("bg-primary", "active-button");
        e.target.classList.add("bg-primary", "active-button");
    }

    if (!isAdmin) return (<Navigate to="/unauthorized" />);
    return (
        <div className="card shadow-xl">
            <div className="card card-side bg-base-100">
                <div className="card-body items-center flex gap-5">
                    <button className="btn btn-md bg-primary border-0 w-2/4 text-xl active-button" onClick={(e) => showData(e, CategoriesEnum.Cuisines)}>Cuisines</button>
                    <button className="btn btn-md border-0 w-2/4 text-xl" onClick={(e) => showData(e, CategoriesEnum.MealTimes)}>Meal Times</button>
                    <button className="btn btn-md border-0 w-2/4 text-xl" onClick={(e) => showData(e, CategoriesEnum.Diets)}>Diets</button>
                    <button className="btn btn-md border-0 w-2/4 text-xl" onClick={(e) => showData(e, CategoriesEnum.DishTypes)}>Dish Types</button>
                    <button className="btn btn-md border-0 w-2/4 text-xl">Ingredients</button>
                </div>
                <div className="card-body">
                    <table className="table table-zebra w-full">
                        <thead>
                        <tr>
                            <th>Name</th>
                            <th></th>
                        </tr>
                        </thead>
                        <tbody>
                        {categories.map(cat => (
                            <tr key={cat.id}>
                                <td>{cat.name}</td>
                                <td></td>
                            </tr>
                        ))}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}