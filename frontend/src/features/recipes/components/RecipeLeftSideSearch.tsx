import { RecipeFilter } from './RecipeFilter';

export const RecipeLeftSideSearch = () => {

  return (
  <div className="drawer">
    <input id="my-drawer" type="checkbox" className="drawer-toggle" />
    <div className="drawer-content">
      <label htmlFor="my-drawer" className="btn drawer-button btn-ghost btn-circle">
        <svg xmlns="http://www.w3.org/2000/svg" className='h-7 w-7' viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"><circle cx="11" cy="11" r="8"></circle><line x1="21" y1="21" x2="16.65" y2="16.65"></line></svg>
      </label>
    </div> 
    <div className="drawer-side">
      <label htmlFor="my-drawer" className="drawer-overlay"></label>
      <ul className="menu p-4 w-80 bg-base-100 text-base-content">
        <div className='sm:container mx-auto'>
          <RecipeFilter/>
        </div>
      </ul>
    </div>
  </div>
  );
};