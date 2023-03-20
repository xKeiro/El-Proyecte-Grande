import { useEffect, useState } from 'react';
import { Navigate, useParams} from 'react-router-dom';
import { RecipesApi } from '@/features/recipes/api/RecipesApi';
import { TRecipe } from '@/features/recipes';


export const EditRecipe = () => {
    const [recipe, setRecipe] = useState<TRecipe | null>(null);
    const { id } = useParams<{ id: string }>();
    const idNumeric = parseInt(id!);

    let isAdmin = true;
export const EditRecipe = ({ isAdmin } : { isAdmin : boolean }) => {

    useEffect(() => {
        RecipesApi.get(idNumeric).then((recipe: TRecipe) => {
            setRecipe(recipe);
        });
    }, []);

    if (isAdmin)
        return (
            <div id="recipe-container" className="">
                <div className=''>
                    <div className="grid grid-cols-3 gap-4 items-center">
                        <div className="bg-primary grid grid-cols-1 bg-base-300 rounded-lg drop-shadow-xl text-xl h-16 items-center">
                            <span className='text-center md:text-center'>Name</span>
                        </div>
                        <input type="text" placeholder={ recipe?.name } className="input input-bordered input-lg col-2 col-span-2  h-16" />

                        <div className="bg-primary grid grid-cols-1 bg-base-300 rounded-lg drop-shadow-xl text-xl h-16 items-center">
                            <span className='text-center md:text-center'>Description</span>
                        </div>
                        <input type="text" placeholder={ recipe?.description } className="input input-bordered input-lg col-2 col-span-2  h-16" />

                        <div className="bg-primary grid grid-cols-1 bg-base-300 rounded-lg drop-shadow-xl text-xl h-16 items-center">
                            <span className='text-center md:text-center'>Difficulty</span>
                            {/* drpodown */}
                        </div>
                        <input type="text" placeholder={ recipe?.name } className="input input-bordered input-lg col-2 col-span-2  h-16" />

                        <div className="bg-primary grid grid-cols-1 bg-base-300 rounded-lg drop-shadow-xl text-xl h-16 items-center">
                            <span className='text-center md:text-center'>Preparation Steps</span>
                            {/* addable input line? */}
                        </div>
                        <input type="text" placeholder={ recipe?.name } className="input input-bordered input-lg col-2 col-span-2  h-16" />

                        <div className="bg-primary grid grid-cols-1 bg-base-300 rounded-lg drop-shadow-xl text-xl h-16 items-center">
                            <span className='text-center md:text-center'>Recipe Ingredients</span>
                            {/* addable dropdown + input + unit */}
                        </div>
                        <input type="text" placeholder={ recipe?.name } className="input input-bordered input-lg col-2 col-span-2  h-16" />

                        <div className="bg-primary grid grid-cols-1 bg-base-300 rounded-lg drop-shadow-xl text-xl h-16 items-center">
                            <span className='text-center md:text-center'>Cuisine</span>
                            {/* drpodown */}
                        </div>
                        <input type="text" placeholder={ recipe?.name } className="input input-bordered input-lg col-2 col-span-2  h-16" />

                        <div className="bg-primary grid grid-cols-1 bg-base-300 rounded-lg drop-shadow-xl text-xl h-16 items-center">
                            <span className='text-center md:text-center'>MealTimes</span>
                            {/* drpodown */}
                        </div>
                        <input type="text" placeholder={ recipe?.name } className="input input-bordered input-lg col-2 col-span-2  h-16" />

                        <div className="bg-primary grid grid-cols-1 bg-base-300 rounded-lg drop-shadow-xl text-xl h-16 items-center">
                            <span className='text-center md:text-center'>Diets</span>
                            {/* drpodown */}
                        </div>
                        <input type="text" placeholder={ recipe?.name } className="input input-bordered input-lg col-2 col-span-2  h-16" />

                        <div className="bg-primary grid grid-cols-1 bg-base-300 rounded-lg drop-shadow-xl text-xl h-16 items-center">
                            <span className='text-center md:text-center'>Dish Type</span>
                            {/* drpodown */}
                        </div>
                        <input type="text" placeholder={ recipe?.name } className="input input-bordered input-lg col-2 col-span-2  h-16" />
                    </div>
                </div>
            </div>
        );
    return (<Navigate to="/unauthorized" />);
};
