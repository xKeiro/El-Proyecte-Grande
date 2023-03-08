import { IngredientsApi } from "@/features/ingredients/api/IngredientsApi";
import { useEffect, useState } from "react";
import { Ingredient } from "@/features/ingredients";

export const AddRecipeChooseIngredient = (props: any) => {
    const [ingredients, setIngredients] = useState<Ingredient[]>([]);
    const [selectedIngredient, setSelectedIngredient] = useState<Ingredient | null>(null);
    const [ingredientAmount, setIngredientAmount] = useState<number>(0);
    const [ingredientList, setIngredientList] = useState<{ ingredient: Ingredient | null, amount: number }[]>([]);
    const [ingredientListToPost, setIngredientListToPost] = useState<{ingredientId : number | null, amount: number}[]>([]);

    useEffect(() => {
        IngredientsApi.getAll().then((Ingredients: Ingredient[]) => {
            setIngredients(Ingredients);
        });
    }, []);

    const handleAddIngredient = () => {
        const newIngredient = { ingredient: selectedIngredient, amount: ingredientAmount };
        const newIngredientToPost = { ingredientId: selectedIngredient.id, amount: ingredientAmount };
        setIngredientList([...ingredientList, newIngredient]);
        setIngredientListToPost([...ingredientListToPost, newIngredientToPost]);
        setSelectedIngredient(null);
        setIngredientAmount(0);
        props.ingredientToPost([...ingredientListToPost, newIngredientToPost])
    };

    return (
        <div className="form-control">
            <label htmlFor="recipeIngredientsAddNew" className="mb-2 font-semibold">
                <span className="mb-2 font-semibold">Select ingredient: </span>
            </label>
            <select
                id="recipeIngredientsAddNew"
                name="recipeIngredientsAddNew"
                className="select select-bordered mb-6"
                value={selectedIngredient?.id ?? ""}
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
                    <span className="mb-2 font-semibold">Ingredient amount: </span>
                </label>
                <input
                    type="number"
                    min="0"
                    className="input input-bordered mb-6"
                    placeholder="Add ingredient amount"
                    value={ingredientAmount}
                    onChange={(event) => setIngredientAmount(Number(event.target.value))}
                />
            </div>
            <div className="float-left">
                <button
                    title="Add ingredient to list"
                    className="btn btn-square btn-ghost mr-2"
                    onClick={handleAddIngredient}
                >
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="#000000" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"><line x1="12" y1="5" x2="12" y2="19"></line><line x1="5" y1="12" x2="19" y2="12"></line></svg>
                </button>
            </div>
        </div>
    )
}
