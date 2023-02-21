import { RecipeFilter } from '../components/RecipeFilter';

export const MainPage = () => {

  return (
  <div className="drawer">
    <input id="my-drawer" type="checkbox" className="drawer-toggle" />
    <div className="drawer-content">
      <label htmlFor="my-drawer" className="btn btn-primary drawer-button">Seacrh options</label>
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