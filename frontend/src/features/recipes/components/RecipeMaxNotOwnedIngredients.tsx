type props = {
  maxNotOwnedIngredients: number;
  handleMaxNotOwnedIngredientsChange: (maxNotOwnedIngredients: number) => void;
};

export const RecipeMaxNotOwnedIngredients: React.FC<props> = ({
  maxNotOwnedIngredients,
  handleMaxNotOwnedIngredientsChange,
}) => {
  const handleClick = (e: React.MouseEvent<HTMLButtonElement, MouseEvent>, value: number) => {
    if ((maxNotOwnedIngredients + value) < 0) {
      return;
    }
    maxNotOwnedIngredients = maxNotOwnedIngredients + value;
    handleMaxNotOwnedIngredientsChange(maxNotOwnedIngredients);
  };

  return (
    <div className="bg-primary w-72 grid grid-cols-1 gap-4 bg-base-300 rounded-lg drop-shadow-xl p-2 content-start items-start">
      <div className="grid grid-cols-2 content-start items-start">
        <div className="text-left text-xl pl-4 mt-2 transition ease-in-out duration-200 hover:animate-none hover:scale-105">
          <div className="tooltip" data-tip="You can set the maximum number of ingredients you don't have at home but can be included in the recipe">
            Not Owned
          </div>
        </div>
        <div>
          <div className="grid grid-cols-3 gap-1 content-start items-start align-center items-center text-center">
            <button className='btn btn-ghost text-xl hover:btn-success' onClick={(event) => { handleClick(event, 1) }}>+</button>
            <div className="tooltip" data-tip="The number of maximum not owned ingredients">
              <span>{maxNotOwnedIngredients}</span>
            </div>
            <button className='btn btn-ghost text-xl hover:btn-error' onClick={(event) => { handleClick(event, -1) }}>-</button>
          </div>
        </div>
      </div>
    </div>
  );
};
