import { useEffect, useState } from 'react';
import { Navigate, useParams} from 'react-router-dom';
import { RecipesApi } from '@/features/recipes/api/RecipesApi';
import { TRecipe } from '@/features/recipes';


export const EditRecipe = ({ isAdmin } : { isAdmin : boolean }) => {
    const [recipe, setRecipe] = useState<TRecipe | null>(null);
    const { id } = useParams<{ id: string }>();
    const idNumeric = parseInt(id!);
    console.log(recipe);
    

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
                        </div>
                        <div className="col-2 col-span-2">
                            <select defaultValue={"default"} className="select w-full max-w-xs h-16 px-8 p-2 shadow bg-base-100 rounded-box w-52 items-center">
                                <option disabled value="default">Original: { recipe?.difficulty }</option>
                                <option value="Easy">Easy</option>
                                <option value="Medium">Medium</option>
                                <option value="Hard">Hard</option>
                            </select>
                        </div>

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
