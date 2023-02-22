import { useEffect, useState} from "react";
import {Navigate} from "react-router-dom";
import {CategoryApi} from "@/features/categories/api/CategoryApi";
import {CategoriesEnum, Category} from "@/features/categories";
import {PropertiesTable} from "@/features/admin/components/PropertiesTable";
import {PropertiesAddNew} from "@/features/admin/components/PropertiesAddNew";

export const RecipeProperties = () => {
    const [categories, setCategories] = useState<Category[]>([]);
    const [isTable, setIsTable] = useState<boolean>(true);
    // const [currentCategory, setCurrentCategory] = useState<CategoriesEnum>(CategoriesEnum.Cuisines);

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
        const activeButton = document.getElementsByClassName("active-button")[0];
        if (activeButton) activeButton.classList.remove("bg-primary-focus", "active-button");
        e.target.classList.add("bg-primary-focus", "active-button");
        setIsTable(true);
        // setCurrentCategory(category);
    }

    const showAddNewForm = () => {
        document.getElementsByClassName("active-button")[0].classList.remove("bg-primary-focus", "active-button");
        setIsTable(false);
    }

    if (!isAdmin) return (<Navigate to="/unauthorized" />);
    return (
        <div className="card shadow-xl">
            <div className="card card-side bg-base-100">
                <div className="card-body items-center flex gap-5 w-2/4">
                    <button className="btn btn-md bg-primary-focus border-0 w-2/4 text-xl active-button" onClick={(e) => showData(e, CategoriesEnum.Cuisines)}>Cuisines</button>
                    <button className="btn btn-md border-0 w-2/4 text-xl" onClick={(e) => showData(e, CategoriesEnum.MealTimes)}>Meal Times</button>
                    <button className="btn btn-md border-0 w-2/4 text-xl" onClick={(e) => showData(e, CategoriesEnum.Diets)}>Diets</button>
                    <button className="btn btn-md border-0 w-2/4 text-xl" onClick={(e) => showData(e, CategoriesEnum.DishTypes)}>Dish Types</button>
                    <button className="btn btn-md border-0 w-2/4 text-xl">Ingredients</button>
                    <button className="btn btn-md btn-success border-0 w-2/4 text-xl mt-10" onClick={showAddNewForm}>
                        <svg xmlns="http://www.w3.org/2000/svg"
                             className="h-5 w-5 mr-1"
                             viewBox="0 0 24 24"
                             fill="none"
                             stroke="currentColor"
                             strokeWidth="2"
                             strokeLinecap="round"
                             strokeLinejoin="round">
                            <line x1="12" y1="5" x2="12" y2="19"></line><line x1="5" y1="12" x2="19" y2="12"></line>
                        </svg>
                        Add New
                    </button>
                </div>
                <div className="card-body w-2/4">
                    {
                        isTable && <PropertiesTable categories={categories} />
                    }
                    {
                        !isTable && <PropertiesAddNew />
                    }
                </div>
            </div>
        </div>
    );
}