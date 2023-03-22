type props = {
  maxNotOwnedIngredients: number | null;
  handleMaxNotOwnedIngredientsChange: (maxNotOwnedIngredients: number | null) => void;
};

export const RecipeMaxNotOwnedIngredients: React.FC<props> = ({
  maxNotOwnedIngredients,
  handleMaxNotOwnedIngredientsChange,
}) => {
  const handleClick = (e: React.MouseEvent<HTMLButtonElement, MouseEvent>, value: number) => {
    if ((maxNotOwnedIngredients != null && maxNotOwnedIngredients + value) < 0) {
      maxNotOwnedIngredients = null;
    }
    else if (maxNotOwnedIngredients == null && value > 0) {
      maxNotOwnedIngredients = 0;
    }
    else if (maxNotOwnedIngredients != null){
      maxNotOwnedIngredients = maxNotOwnedIngredients + value;
    }
    else{
      return;
    }
    handleMaxNotOwnedIngredientsChange(maxNotOwnedIngredients);
  };

  return (
    <div className="bg-primary w-72 grid grid-cols-1 gap-4 bg-base-300 rounded-lg drop-shadow-xl p-2 content-start items-start">
      <div className="grid grid-cols-2 content-start items-start">
        <div className="text-left text-xl pl-4 mt-2 transition ease-in-out duration-200 hover:animate-none hover:scale-105">
          <div className="tooltip" data-tip="You can set the maximum number of ingredients you don't have at home but can be included in the recipes">
            Not Owned
          </div>
        </div>
        <div>
          <div className="grid grid-cols-3 gap-1 content-start items-start align-center items-center text-center">
            <button className='btn btn-ghost text-xl hover:btn-error' onClick={(event) => { handleClick(event, -1) }}>-</button>
            <div className="tooltip" data-tip="The number of maximum not owned ingredients">
              <span>{maxNotOwnedIngredients != null ? maxNotOwnedIngredients : "Any"}</span>
            </div>
            <button className='btn btn-ghost text-xl hover:btn-success' onClick={(event) => { handleClick(event, 1) }}>+</button>
          </div>
        </div>
      </div>
    </div>
  );
};
