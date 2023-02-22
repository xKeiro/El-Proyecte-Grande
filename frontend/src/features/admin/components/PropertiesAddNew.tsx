import { CategoriesEnum } from "@/features/categories";
import {useState} from "react";
export const PropertiesAddNew = () => {
    const [isIngredient, setIsIngredient] = useState<boolean>(false);

    const handleChange = (prop : string) => {
        setIsIngredient(prop == "Ingredients");
    }

    return (
        <div className="card h-full w-3/5">
            <select id="properties" className="select select-bordered w-2/4 mb-6" onChange={(e) => handleChange(e.target.value)}>
                <option value={CategoriesEnum.Cuisines}>Cuisine</option>
                <option value={CategoriesEnum.MealTimes}>Meal Time</option>
                <option value={CategoriesEnum.Diets}>Diet</option>
                <option value={CategoriesEnum.DishTypes}>Dish Type</option>
                <option value="Ingredients">Ingredient</option>
            </select>
            <div className="form-control">
                {
                    !isIngredient &&
                    <label className="input-group input-group-md">
                        <span>Name</span>
                        <input type="text" placeholder="Type here" className="input input-bordered input-md" />
                    </label>
                }
                {
                    isIngredient &&
                    <div className="flex flex-col gap-4">
                        <label className="input-group input-group-md">
                            <span>Name</span>
                            <input type="text" placeholder="Type here" className="input input-bordered input-md" />
                        </label>
                        <label className="input-group input-group-md">
                            <span>Unit of Measure</span>
                            <input type="text" placeholder="Etc.: g, dl, pcs" className="input input-bordered input-md" />
                        </label>
                        <label className="input-group input-group-md">
                            <span>Calorie</span>
                            <input type="number" placeholder="Cal" className="input input-bordered input-md" />
                        </label>
                        <span className="label-text-alt">Cal = kcal / 1000</span>
                    </div>
                }
            </div>
        </div>
    );
}