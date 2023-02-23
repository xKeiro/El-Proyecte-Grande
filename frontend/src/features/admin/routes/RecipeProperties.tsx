import { useEffect, useState} from "react";
import {Navigate} from "react-router-dom";
import {CategoryApi} from "@/features/categories/api/CategoryApi";
import {IngredientsApi} from "@/features/ingredients/api/IngredientsApi";
import {CategoriesEnum, Category} from "@/features/categories";
import {PropertiesTable} from "@/features/admin/components/PropertiesTable";
import {PropertiesAddNew} from "@/features/admin/components/PropertiesAddNew";
import {Ingredient} from "@/features/ingredients";

export const RecipeProperties = () => {
    const [categories, setCategories] = useState<Category[]>([]);
    const [ingredients, setIngredients] = useState<Ingredient[]>([]);
    const [isTable, setIsTable] = useState<boolean>(true);

    let isAdmin = true;

    useEffect(() => {
        const fetchData = async () => {
            const result = await CategoryApi.getAll(CategoriesEnum.Cuisines);
            setCategories(result);
        };
        fetchData();
    }, []);

    const showData = (e : any) => {
        const category = e.target.dataset.proptype;
        if (category != "Ingredients") CategoryApi.getAll(category).then(res => {
            setCategories(res);
            setIngredients([]);
        });
        else IngredientsApi.getAll().then(res => {
            setIngredients(res);
            setCategories([]);
        });

        const activeButton = document.getElementsByClassName("active-button")[0];
        if (activeButton) activeButton.classList.remove("bg-primary-focus", "active-button");
        e.target.classList.add("bg-primary-focus", "active-button");
        setIsTable(true);
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
                    <button className="btn btn-md bg-primary-focus border-0 w-2/4 text-xl active-button"
                            data-proptype={CategoriesEnum.Cuisines} onClick={(e) => showData(e)}>Cuisines
                    </button>
                    <button className="btn btn-md border-0 w-2/4 text-xl"
                            data-proptype={CategoriesEnum.MealTimes} onClick={(e) => showData(e)}>Meal Times
                    </button>
                    <button className="btn btn-md border-0 w-2/4 text-xl"
                            data-proptype={CategoriesEnum.Diets} onClick={(e) => showData(e)}>Diets
                    </button>
                    <button className="btn btn-md border-0 w-2/4 text-xl"
                            data-proptype={CategoriesEnum.DishTypes} onClick={(e) => showData(e)}>Dish Types
                    </button>
                    <button className="btn btn-md border-0 w-2/4 text-xl"
                            data-proptype="Ingredients" onClick={(e) => showData(e)}>Ingredients
                    </button>
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
                        isTable && <PropertiesTable categories={categories} ingredients={ingredients} />
                    }
                    {
                        !isTable && <PropertiesAddNew />
                    }
                </div>
            </div>
        </div>
    );
}