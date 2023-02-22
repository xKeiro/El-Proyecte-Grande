import { RecipeFilter } from './RecipeFilter';
import { TRecipe } from '../types';
import { AllRecipes } from '../routes/AllRecipes';

export const RecipeLeftSideSearch = ({ setFilteredRecipes }) => {

  function handleData(data: TRecipe[]) {
    console.log("Received data:", data);
    setFilteredRecipes(data);
  }
  return (
    <div className="drawer">
      <input id="left-side-search" type="checkbox" className="drawer-toggle" />
      <div className="drawer-content">
      {/* Page content here */}
        <label htmlFor="left-side-search" className="btn drawer-button text-center text-xl w-70 h-16 bg-base-300 p-2 rounded-lg drop-shadow-xl">
          <svg xmlns="http://www.w3.org/2000/svg" className='h-7 w-7 pr-2' viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"><circle cx="11" cy="11" r="8"></circle><line x1="21" y1="21" x2="16.65" y2="16.65"></line></svg>
          Search Options
          </label>
      </div> 
      <div className="drawer-side">
        <label htmlFor="left-side-search" className="drawer-overlay"></label>
        <ul className="menu p-4 w-80 bg-base-100 text-base-content">
          <div className='sm:container mx-auto'>
            <RecipeFilter onData={handleData}/>
          </div>
        </ul>
      </div>
    </div>
  
    );
  

};