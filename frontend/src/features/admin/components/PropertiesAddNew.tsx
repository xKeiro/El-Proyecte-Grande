import React, {useState} from "react";
import { CategoryApi } from "@/features/categories/api/CategoryApi";
import { IngredientsApi } from "@/features/ingredients/api/IngredientsApi";
import { CategoriesEnum } from "@/features/categories";

export const PropertiesAddNew = () => {
    const [isIngredient, setIsIngredient] = useState<boolean>(false);
    const [category, setCategory] = useState<CategoriesEnum>(CategoriesEnum.Cuisines);
    const [responseMsg, setResponseMsg] = useState<string>();
    const [responseMsgColor, setResponseMsgColor] = useState<string>();

    const handleChange = (prop : string) => {
        setIsIngredient(prop == "Ingredients");
        if (prop != "Ingredients") setCategory(prop as CategoriesEnum);
        setResponseMsg("");
        (document.getElementById("newName") as HTMLInputElement).value = "";
    }

    const sendData = async () => {
        const inputFields = Array.from(document.querySelectorAll("input"));
        if (inputFields.every(inp => inp.value != "")) {
            if (inputFields[0].value.length >= 2) {
                if (+inputFields[2].value >= 0) {
                    const newName = (document.getElementById("newName") as HTMLInputElement).value;
                    let unitOfMeasure;
                    let calorie;
                    let res : any;

                    if (isIngredient) {
                        unitOfMeasure = (document.getElementById("unitOfMeasure") as HTMLInputElement).value;
                        calorie = +(document.getElementById("calorie") as HTMLInputElement).value;

                        res = await IngredientsApi.add(newName, unitOfMeasure, calorie);
                    } else {
                        res = await CategoryApi.add(category, newName);
                    }

                    if (typeof res == "object") {
                        setResponseMsgColor("text-success");
                        setResponseMsg("Successfully created!");
                    }
                    else {
                        setResponseMsgColor("text-error");
                        setResponseMsg(res);
                    }
                }
                else {
                    setResponseMsgColor("text-error");
                    setResponseMsg("Calorie can't be a negative number!");
                }
            }
            else {
                setResponseMsgColor("text-error");
                setResponseMsg("Name must be min 2 characters long!");
            }
        }
        else {
            setResponseMsgColor("text-error");
            setResponseMsg("All fields are required!");
        }
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
                        <span>Name<span className="text-error px-0 ml-2">*</span></span>
                        <input id="newName" type="text" placeholder="Type here" minLength={2} maxLength={20} className="input input-bordered input-md" />
                    </label>
                }
                {
                    isIngredient &&
                    <div className="flex flex-col gap-4">
                        <label className="input-group input-group-md">
                            <span>Name<span className="text-error px-0 ml-2">*</span></span>
                            <input id="newName" type="text" placeholder="Type here" minLength={2} maxLength={60} className="input input-bordered input-md" />
                        </label>
                        <label className="input-group input-group-md">
                            <span>Unit of Measure<span className="text-error px-0 ml-2">*</span></span>
                            <input id="unitOfMeasure" type="text" placeholder="Etc.: g, ml, pcs" minLength={1} maxLength={25} className="input input-bordered input-md" />
                        </label>
                        <label className="input-group input-group-md">
                            <span>Calorie<span className="text-error px-0 ml-2">*</span></span>
                            <input id="calorie" type="number" placeholder="Cal" min={0} className="input input-bordered input-md" />
                        </label>
                        <span className="label-text-alt">Cal = pcs, cloves / kcal </span>
                        <span className="label-text-alt">Cal = 100g / kcal</span>
                    </div>
                }
                <button className="btn btn-primary mt-5 w-1/4" onClick={sendData}>Add</button>
                <span className={"font-bold mt-5 " + responseMsgColor}>{responseMsg}</span>
            </div>
        </div>
    );
}