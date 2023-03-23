import axios from "axios";
import { useState, useEffect } from "react";
import { useNavigate } from 'react-router-dom';
import { API_URL } from "@/config";
import { CategoriesEnum } from "@/features/categories";
import { CategoryApi } from "@/features/categories/api/CategoryApi";
import { Category } from "@/features/categories";
import { RecipeAddNewPreparationStep } from "./RecipeAddNewPreparationStep";
import { AddRecipeChooseIngredient } from "./RecipeAddChoosenIngredient";
import { PreparationDifficulty, PreparationStep, RecipeIngredientToPost } from "@/features/recipes";
import { RecipesApi } from "@/features/recipes/api/RecipesApi";
import { RequiredStar } from "@/components/Form/RequiredStar";

export const RecipeAddNew = () => {
  const navigate = useNavigate();
  const [cuisines, setCuisines] = useState<Category[]>([]);
  const [mealTimes, setMealTimes] = useState<Category[]>([]);
  const [diets, setDiets] = useState<Category[]>([]);
  const [dishTypes, setDishTypes] = useState<Category[]>([]);

  const [recipeName, setRecipeName] = useState<string>('');
  const [recipeDescription, setRecipeDescription] = useState<string>('');
  const [difficulty, setDifficulty] = useState<PreparationDifficulty>(PreparationDifficulty.Easy);

  const [cuisineId, setCuisineId] = useState<number>(0);
  const [mealTimeIds, setMealTimeIds] = useState<number[]>([]);
  const [dietIds, setDietIds] = useState<number[]>([]);
  const [dishTypeId, setDishTypeId] = useState<number>(0);

  const [recipeIngredientsAddNew, setChildDataIngredientToPost] = useState<RecipeIngredientToPost[]>()
  const [preparationStepsWithoutIds, setPreparationSteps] = useState<PreparationStep[]>();

  const [recipeImage, setRecipeImage] = useState<File | null>(null);
  const [imageId, setImageId] = useState<number>(0);

  const [showImageUpload, setShowImageUpload] = useState(false);
  const [recipeSavedWithoutImage, setRecipeSavedWithoutImage] = useState(false);

  useEffect(() => {
    CategoryApi.getAll(CategoriesEnum.Cuisines).then((Cuisines: Category[]) => {
      setCuisines(Cuisines);
    });
    CategoryApi.getAll(CategoriesEnum.MealTimes).then((MealTimes: Category[]) => {
      setMealTimes(MealTimes);
    });
    CategoryApi.getAll(CategoriesEnum.Diets).then((Diets: Category[]) => {
      setDiets(Diets);
    });
    CategoryApi.getAll(CategoriesEnum.DishTypes).then((DishTypes: Category[]) => {
      setDishTypes(DishTypes);
    });
  }, []);

  const handleIngredientsToPost = (recipeIngredientsAddNew: RecipeIngredientToPost[]) => {
    setChildDataIngredientToPost(recipeIngredientsAddNew)
  }

  const handlePreparationStepsToPost = (preparationStepsWithoutIds: PreparationStep[]) => {
    setPreparationSteps(preparationStepsWithoutIds)
  }

  const handleMealTimeIds = (event: React.ChangeEvent<HTMLSelectElement>) => {
    const options = event.target.selectedOptions;
    const values: number[] = [];
    for (let i = 0; i < options.length; i++) {
      values.push(parseInt(options[i].value));
    }
    setMealTimeIds(prevMealTimeIds => {
      const newMealTimeIds = [...prevMealTimeIds];
      for (const value of values) {
        if (newMealTimeIds.includes(value)) {
          const index = newMealTimeIds.indexOf(value);
          newMealTimeIds.splice(index, 1);
        } else {
          newMealTimeIds.push(value);
        }
      }
      return newMealTimeIds;
    });
  };

  const handleDietIds = (event: React.ChangeEvent<HTMLSelectElement>) => {
    const options = event.target.selectedOptions;
    const values: number[] = [];
    for (let i = 0; i < options.length; i++) {
      values.push(parseInt(options[i].value));
    }
    setDietIds(prevDietIds => {
      const newDietIds = [...prevDietIds];
      for (const value of values) {
        if (newDietIds.includes(value)) {
          const index = newDietIds.indexOf(value);
          newDietIds.splice(index, 1);
        }
        else {
          newDietIds.push(value);
        }
      }
      return newDietIds;
    });
  }

  const handleSubmitRecipeWithoutImage = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    setShowImageUpload(true);
    const recipe = {
      name: recipeName,
      description: recipeDescription,
      difficulty,
      preparationStepsWithoutIds,
      recipeIngredientsAddNew,
      cuisineId,
      mealTimeIds,
      dietIds,
      dishTypeId
    };

    const response = await axios.post(`${API_URL}/recipes`, recipe, { withCredentials: true });
    console.log(response.data.id);
    setImageId(response.data.id);
    setRecipeSavedWithoutImage(true);
  };

  useEffect(() => {
    if (recipeImage != null) {
      const formData = new FormData();
      formData.append("image", recipeImage);
      axios.post(`${API_URL}/ImageUpload`, formData);
    }
  }, [recipeImage]);

  const handleSaveWholeRecipe = () => {
    console.log("Ok")
    navigate('/admin/recipes');
  }

  const handleImageUpload = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (event.target.files != null) {
      const originalFile = event.target.files[0];
      const newFileName = `${imageId.toString()}.${originalFile.name.split('.').pop()}`;
      const newFile = new File([originalFile], newFileName, { type: originalFile.type });
      setRecipeImage(newFile);
    }
  };

  return (
    <div className='sm:container mx-auto'>
      <div className="hero-content flex-col lg:flex-row-reverse mx-auto">
        <div className="card flex-shrink-0 w-full max-w-xl">

          <h1 className="text-4xl font-bold mb-2">Add New Recipe</h1>
          <form onSubmit={handleSubmitRecipeWithoutImage}>
            <div className="form-control">
              <label className="mb-2 font-semibold">
                <h3 className="text-2xl font-bold mb-2">Recipe title<RequiredStar /></h3>
              </label>
              <input
                type="text"
                id="name"
                className="input input-bordered mb-6"
                placeholder="Recipe title" value={recipeName}
                onChange={(event) => setRecipeName(event.target.value)}
                required
              />
            </div>
            <div className="form-control">
              <label htmlFor="description" className="mb-2 font-semibold">
                <h3 className="text-2xl font-bold mb-2">Recipe description<RequiredStar /></h3>
              </label>
              <textarea
                className="textarea textarea-bordered mb-6"
                id="description"
                name="description"
                placeholder="Recipe description"
                value={recipeDescription}
                onChange={(event) => setRecipeDescription(event.target.value)}
                required
              />
            </div>

            <div className="form-control">
              <label htmlFor="difficulty" className="mb-2 font-semibold">
                <h3 className="text-2xl font-bold mb-2">Recipe title<RequiredStar /></h3>
              </label>
              <select
                id="difficulty"
                name="difficulty"
                className="select select-bordered mb-6"
                value={difficulty}
                onChange={(event) => setDifficulty(event.target.value as PreparationDifficulty)}
                required
              >
                <option value="">Select difficulty</option>
                <option value={PreparationDifficulty.Easy}>Easy</option>
                <option value={PreparationDifficulty.Medium}>Medium</option>
                <option value={PreparationDifficulty.Hard}>Hard</option>
              </select>
            </div>

            <div className="form-control">
              <h3 className="text-2xl font-bold mb-2">Preparation steps<RequiredStar /></h3>
              <RecipeAddNewPreparationStep handlePreparationStepsToPost={handlePreparationStepsToPost} />
            </div>


            <div className="form-control">
              <h3 className="text-2xl font-bold mb-2 mt-6">Ingredients<RequiredStar /></h3>
              <AddRecipeChooseIngredient handleIngredientsToPost={handleIngredientsToPost} />
            </div>

            <div>
              <h3 className="text-2xl font-bold mb-2 mt-6">Categories</h3>
              <div className="form-control">
                <label htmlFor="cuisineId" className="mb-2 font-semibold">
                  <span className="mb-2 font-semibold">Cuisine<RequiredStar /></span>
                </label>
                <select
                  id="cuisineId"
                  name="cuisineId"
                  className="select select-bordered mb-6"
                  value={cuisineId}
                  onChange={(event) => setCuisineId(parseInt(event.target.value))}
                  required
                >
                  <option value="">Select cuisine</option>
                  {cuisines.map((cuisine) => (
                    <option key={cuisine.id} value={cuisine.id}>{cuisine.name}</option>
                  ))}
                </select>
              </div>

              <div className="form-control">
                <label htmlFor="dietIds" className="mb-2 font-semibold">
                  <span className="mb-2 font-semibold">Dish types<RequiredStar /></span>
                </label>
                <select
                  id="dishTypeIds"
                  name="dishTypeIds"
                  title="Select dish type"
                  className="select select-bordered mb-6"
                  value={dishTypeId}
                  onChange={(event) => setDishTypeId(parseInt(event.target.value))}
                  required
                >
                  <option value="">Select dish type</option>
                  {dishTypes.map((dishType) => (
                    <option key={dishType.id} value={dishType.id}>{dishType.name}</option>
                  ))}
                </select>
              </div>
            </div>

            <div className="form-control">
              <label htmlFor="mealTimeIds" className="mb-2 font-semibold">
                <span className="mb-2 font-semibold">Meal time<RequiredStar /></span>
              </label>
              <select
                multiple
                id="mealTimeIds"
                name="mealTimeIds"
                className="select select-bordered mb-6"
                value={mealTimeIds.map(String)}
                onChange={handleMealTimeIds}
                required
              >
                <option value="">Select meal time</option>
                {mealTimes.map((mealTime) => (
                  <option key={mealTime.id} value={mealTime.id}>{mealTime.name}</option>
                ))}
              </select>
            </div>
            <div className="form-control">
              <label htmlFor="dietIds" className="mb-2 font-semibold">
                <span className="mb-2 font-semibold">Diets<RequiredStar /></span>
              </label>
              <select
                multiple
                id="dietIds"
                name="dietIds"
                className="select select-bordered mb-6"
                value={dietIds.map(String)}
                onChange={handleDietIds}
                required
              >
                <option value="">Select diet</option>
                {diets.map((diet) => (
                  <option key={diet.id} value={diet.id}>{diet.name}</option>
                ))}
              </select>
            </div>

            <div className="flex justify-center">
              <button type="submit" className="btn btn-active btn-success mt-2 w-1/3">Add Recipe</button>
            </div>
          </form>
          {showImageUpload && (
            <div className="form-control">
              <hr className="border border-bg-300 my-4" />
              <h3 className="text-2xl font-bold mb-2">Upload Image</h3>
              <input type="file" className="mb-2 file-input file-input-bordered w-full mb-2" title="Add image" onChange={handleImageUpload} />
              <div className="flex justify-between">
                <button className="btn btn-active btn-warning mt-2 w-1/3" onClick={handleSaveWholeRecipe}>Save Without Image</button>
                <button className="btn btn-active btn-success mt-2 w-1/3" onClick={handleSaveWholeRecipe}>Save</button>
              </div>
            </div>
          )}

        </div>
      </div>
    </div>
  );
}
