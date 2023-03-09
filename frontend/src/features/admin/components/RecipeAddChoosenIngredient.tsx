import { IngredientsApi } from "@/features/ingredients/api/IngredientsApi";
import { useEffect, useState } from "react";
import { Ingredient } from "@/features/ingredients";
import { RecipeIngredientToPost } from "@/features/recipes";

type props = {
    handleIngredientsToPost: (recipeIngredientsAddNew: RecipeIngredientToPost[]) => void;
}

export const AddRecipeChooseIngredient: React.FC<props> = ({
    handleIngredientsToPost
}) => {
    const [ingredients, setIngredients] = useState<Ingredient[]>([]);
    const [selectedIngredient, setSelectedIngredient] = useState<Ingredient | null>(null);
    const [ingredientAmount, setIngredientAmount] = useState<number>(0);
    const [ingredientList, setIngredientList] = useState<{ ingredient: Ingredient, amount: number }[]>([]);
    const [ingredientListToPost, setIngredientListToPost] = useState<RecipeIngredientToPost[]>([]);

    useEffect(() => {
        IngredientsApi.getAll().then((Ingredients: Ingredient[]) => {
            setIngredients(Ingredients);
        });
    }, []);

    const handleAddIngredient = () => {
        if (selectedIngredient != null) {
            const newIngredient = { ingredient: selectedIngredient, amount: ingredientAmount };
            const newIngredientToPost: RecipeIngredientToPost = { ingredientId: selectedIngredient.id, amount: ingredientAmount };
            setIngredientList([...ingredientList, newIngredient]);
            setIngredientListToPost([...ingredientListToPost, newIngredientToPost]);
            setSelectedIngredient(null);
            setIngredientAmount(0);
            handleIngredientsToPost([...ingredientListToPost, newIngredientToPost])
        }
    };

    const handleDeleteRecipeIngredient = (index: number) => {
        const updatedIngredientList = [...ingredientList];
        updatedIngredientList.splice(index, 1);
        setIngredientList(updatedIngredientList);
    
        const updatedIngredientListToPost = [...ingredientListToPost];
        updatedIngredientListToPost.splice(index, 1);
        
        setIngredientListToPost(updatedIngredientListToPost);    
        handleIngredientsToPost(updatedIngredientListToPost);
    }

    return (
        <div className="form-control">
            {ingredientList.length > 0 ? (
                <div className="p-4">
                    <span><b>Added ingredients:</b></span>
                    <ul>
                        {ingredientList.map((ingredient, index) => (
                            <li key={index} className="pl-2 cursor-pointer"
                                onClick={() => handleDeleteRecipeIngredient(index)}>
                                {ingredient.amount}{ingredient.ingredient.unitOfMeasure} {ingredient.ingredient.name}
                            </li>
                        ))}
                    </ul>
                </div>
            ) : ("")}

            <label htmlFor="recipeIngredientsAddNew" className="mb-2 font-semibold">
                <span className="mb-2 font-semibold">Select ingredient<span className="text-error px-0 ml-2">*</span></span>
            </label>
            <select
                id="recipeIngredientsAddNew"
                name="recipeIngredientsAddNew"
                className="select select-bordered mb-6"
                //value={selectedIngredient?.id ?? ""}
                required
                onChange={(event) => {
                    const ingredientId = parseInt(event.target.value);
                    const selected = ingredients.find(i => i.id === ingredientId);
                    setSelectedIngredient(selected ?? null);
                }}
            >
                <option value="">Select ingredient</option>
                {ingredients.map((ingredient) => (
                    <option key={ingredient.id} value={ingredient.id}>{ingredient.name} ({ingredient.unitOfMeasure})</option>
                ))}
            </select>
            <div className="form-control">
                <label className="mb-2 font-semibold">
                    <span className="mb-2 font-semibold">Ingredient amount<span className="text-error px-0 ml-2">*</span></span>
                </label>
                <input
                    type="number"
                    min="0"
                    className="input input-bordered"
                    placeholder="Add ingredient amount"
                    //value={ingredientAmount}
                    onChange={(event) => setIngredientAmount(Number(event.target.value))}
                    required
                />
            </div>
            <div className="float-left">
                <button
                    title="Add ingredient to list"
                    className="btn btn-square btn-success mr-2 mt-2"
                    onClick={handleAddIngredient}
                >
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="#000000" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"><line x1="12" y1="5" x2="12" y2="19"></line><line x1="5" y1="12" x2="19" y2="12"></line></svg>
                </button>
            </div>
        </div>
    )
}
