import { useEffect, useRef, useState } from 'react';
import { RecipesApi } from '../api/RecipesApi';
import { CategoryApi } from '@/features/categories/api/CategoryApi';
import { IngredientsApi } from '@/features/ingredients/api/IngredientsApi';
import { RecipeSearchBox } from './RecipeSearchBox';
import { RecipeSingleCategorySelector } from './RecipeSingleCategorySelector';
import { Category } from '@/features/categories/';
import { IngredientForSearch } from '@/features/ingredients/';
import { CategoriesEnum } from '@/features/categories/';
import { RecipeMaxNotOwnedIngredients } from './RecipeMaxNotOwnedIngredients';
import { PreparationDifficulty, TRecipe, TRecipesFilter, TRecipesWithPagination } from '../types';
import { RecipeDifficultySelector } from './RecipeDifficultySelector';

type props = {
  handleFilteringResult: (filter: TRecipesFilter) => void;
};

export const RecipeFilter: React.FC<props> = ({
  handleFilteringResult,
}) => {
  const [cuisines, setCuisines] = useState<Category[]>([]);
  const [diets, setDiets] = useState<Category[]>([]);
  const [mealTimes, setMealTimes] = useState<Category[]>([]);
  const [dishTypes, setDishTypes] = useState<Category[]>([]);
  const [ingredients, setIngredients] = useState<IngredientForSearch[]>([]);
  const [preparationMaxDifficulty, setPreparationDifficulty] = useState<PreparationDifficulty | null>(null);
  const [maxNotOwnedIngredients, setMaxNotOwnedIngredients] = useState<number | null>(null);
  const [searchTerm, setSearchTerm] = useState<string>('');
  const [selectedCuisines, setSelectedCuisines] = useState<Category[]>([]);
  const [selectedDiets, setSelectedDiets] = useState<Category[]>([]);
  const [selectedMealTimes, setSelectedMealTimes] = useState<Category[]>([]);
  const [selectedDishTypes, setSelectedDishTypes] = useState<Category[]>([]);
  const [selectedIngredients, setSelectedIngredients] = useState<IngredientForSearch[]>([]);


  const handleSubmit = async () => {
    // event.preventDefault();
    const selectedCuisineIds = selectedCuisines.map(cuisine => cuisine.id);
    const selectedDietIds = selectedDiets.map(diet => diet.id);
    const selectedMealTimeIds = selectedMealTimes.map(mealTime => mealTime.id);
    const selectedDishTypeIds = selectedDishTypes.map(dishType => dishType.id)
    const selectedIngredientIds = selectedIngredients.map(ingredient => ingredient.id)

    const searchString = (document.getElementById("search-field") as HTMLInputElement).value;
    const filter: TRecipesFilter = {
      cuisineIds: selectedCuisineIds,
      dietIds: selectedDietIds,
      mealTimeIds: selectedMealTimeIds,
      dishTypeIds: selectedDishTypeIds,
      ingredientIds: selectedIngredientIds,
      searchString: searchString,
      preparationMaxDifficulty: preparationMaxDifficulty,
      maxNotOwnedIngredients: maxNotOwnedIngredients,
      page: 1,
      recipesPerPage: 5,
    }
    handleFilteringResult(filter)
  };

  useEffect(() => {
    CategoryApi.getAll(CategoriesEnum.Cuisines).then((Cuisines: Category[]) => {
      setCuisines(Cuisines);
    });
    CategoryApi.getAll(CategoriesEnum.Diets).then((Diets: Category[]) => {
      setDiets(Diets);
    });
    CategoryApi.getAll(CategoriesEnum.MealTimes).then((MealTimes: Category[]) => {
      setMealTimes(MealTimes);
    });
    CategoryApi.getAll(CategoriesEnum.DishTypes).then((DishTypes: Category[]) => {
      setDishTypes(DishTypes);
    });
    IngredientsApi.getAll().then((Ingredients: IngredientForSearch[]) => {
      setIngredients(Ingredients);
    });
    handleSubmit();
  }, []);

  const handleCuisineSelection = (cuisine: Category) => {
    selectedCuisines.push(cuisine);
    const indexToRemove = cuisines.indexOf(cuisine);
    if (indexToRemove > -1) {
      cuisines.splice(indexToRemove, 1);
    }
    setSelectedCuisines(selectedCuisines.map((cuisine) => cuisine));
  };
  const handleDietSelection = (diet: Category) => {
    selectedDiets.push(diet);
    const indexToRemove = diets.indexOf(diet);
    if (indexToRemove > -1) {
      diets.splice(indexToRemove, 1);
    }
    setSelectedDiets(selectedDiets.map((diets) => diets));
  };
  const handleMealTimeSelection = (mealTime: Category) => {
    selectedMealTimes.push(mealTime);
    const indexToRemove = mealTimes.indexOf(mealTime);
    if (indexToRemove > -1) {
      mealTimes.splice(indexToRemove, 1);
    }
    setSelectedMealTimes(selectedMealTimes.map((mealTime) => mealTime));
  };
  const handleDishTypeSelection = (dishType: Category) => {
    selectedDishTypes.push(dishType);
    const indexToRemove = dishTypes.indexOf(dishType);
    if (indexToRemove > -1) {
      dishTypes.splice(indexToRemove, 1);
    }
    setSelectedDishTypes(selectedDishTypes.map((dishType) => dishType));
  };
  const handleIngredientSelection = (ingredient: IngredientForSearch) => {
    selectedIngredients.push(ingredient);
    const indexToRemove = ingredients.indexOf(ingredient);
    if (indexToRemove > -1) {
      ingredients.splice(indexToRemove, 1)
    }
    setSelectedIngredients(selectedIngredients.map((ingredient) => ingredient))
  };
  const handleCuisineSelectionRemoval = (cuisine: Category) => {
    cuisines.push(cuisine);
    const indexToRemove = selectedCuisines.indexOf(cuisine);
    cuisines.sort((a, b) => a.name.localeCompare(b.name));
    if (indexToRemove > -1) {
      selectedCuisines.splice(indexToRemove, 1);
    }
    setCuisines(cuisines.map((cuisine) => cuisine));
  };
  const handleDietSelectionRemoval = (diet: Category) => {
    diets.push(diet);
    const indexToRemove = selectedDiets.indexOf(diet);
    diets.sort((a, b) => a.name.localeCompare(b.name));
    if (indexToRemove > -1) {
      selectedDiets.splice(indexToRemove, 1);
    }
    setDiets(diets.map((diet) => diet));
  };
  const handleMealTimeSelectionRemoval = (mealTime: Category) => {
    mealTimes.push(mealTime);
    mealTimes.sort((a, b) => a.name.localeCompare(b.name));
    const indexToRemove = selectedMealTimes.indexOf(mealTime);
    if (indexToRemove > -1) {
      selectedMealTimes.splice(indexToRemove, 1);
    }
    setMealTimes(mealTimes.map((mealTime) => mealTime));
  };
  const handleDishTypeSelectionRemoval = (dishType: Category) => {
    dishTypes.push(dishType);
    dishTypes.sort((a, b) => a.name.localeCompare(b.name));
    const indexToRemove = selectedDishTypes.indexOf(dishType);
    if (indexToRemove > -1) {
      selectedDishTypes.splice(indexToRemove, 1);
    }
    setDishTypes(dishTypes.map((dishType) => dishType));
  };
  const handleIngredientRemoval = (ingredient: IngredientForSearch) => {
    ingredients.push(ingredient);
    ingredients.sort((a, b) => a.name.localeCompare(b.name));
    const indexToRemove = selectedIngredients.indexOf(ingredient);
    if (indexToRemove > -1) {
      selectedIngredients.splice(indexToRemove, 1);
    }
    setIngredients(ingredients.map((ingredient) => ingredient));
  };
  const handlePreparationDifficultySelection = (preparationDifficulty: PreparationDifficulty) => {
    setPreparationDifficulty(preparationDifficulty);
  };
  const handleMaxNotOwnedIngredientsChange = (maxNotOwnedIngredients: number) => {
    setMaxNotOwnedIngredients(maxNotOwnedIngredients);
  };


  return (
    <div>
    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4 justify-items-center auto-cols-fr text-xl mx-auto">
      <div className="md:col-span-2 lg:col-span-3 w-full text-center">
        <RecipeSearchBox searchTerm={searchTerm} setSearchTerm={setSearchTerm} handleRecipeSearch={handleSubmit} />
      </div>
      <RecipeSingleCategorySelector
        categories={cuisines}
        categoryShowedName="Cuisines"
        categoryName={CategoriesEnum.Cuisines}
        selectedCategories={selectedCuisines}
        handleCategorySelection={handleCuisineSelection}
        handleCategorySelectionRemoval={handleCuisineSelectionRemoval}
      />
      <RecipeSingleCategorySelector
        categories={diets}
        categoryShowedName="Diets"
        categoryName={CategoriesEnum.Diets}
        selectedCategories={selectedDiets}
        handleCategorySelection={handleDietSelection}
        handleCategorySelectionRemoval={handleDietSelectionRemoval}
      />
      <RecipeSingleCategorySelector
        categories={mealTimes}
        categoryShowedName="Meal Times"
        categoryName={CategoriesEnum.MealTimes}
        selectedCategories={selectedMealTimes}
        handleCategorySelection={handleMealTimeSelection}
        handleCategorySelectionRemoval={handleMealTimeSelectionRemoval}
      />
      <RecipeSingleCategorySelector
        categories={dishTypes}
        categoryShowedName="Dish Types"
        categoryName={CategoriesEnum.DishTypes}
        selectedCategories={selectedDishTypes}
        handleCategorySelection={handleDishTypeSelection}
        handleCategorySelectionRemoval={handleDishTypeSelectionRemoval}
      />
        <RecipeDifficultySelector
          preparationMaxDifficulty={preparationMaxDifficulty}
          handlePreparationDifficultySelection={handlePreparationDifficultySelection}
        />
      <RecipeSingleCategorySelector
        categories={ingredients}
        categoryShowedName="Ingredients"
        categoryName={CategoriesEnum.Ingredients}
        selectedCategories={selectedIngredients}
        handleCategorySelection={handleIngredientSelection}
        handleCategorySelectionRemoval={handleIngredientRemoval}
      />
      <div className='md:col-span-2 lg:col-span-3'>
      <RecipeMaxNotOwnedIngredients
        maxNotOwnedIngredients={maxNotOwnedIngredients}
        handleMaxNotOwnedIngredientsChange={handleMaxNotOwnedIngredientsChange}
      />
      </div>
      
    </div>
    <div className="mx-auto text-center my-5"><button className="btn btn-active btn-ghost hover:btn-warning text-xl" type='submit' onClick={handleSubmit}>Search</button></div>
    </div>
  );
};
