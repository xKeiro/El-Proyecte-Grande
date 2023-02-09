import './adminPage.css';
import { Route, Routes } from 'react-router-dom';
import Users from './components/Users';
import Navbar from './components/Navbar';
import Recipes from './components/Recipes';
import Recipe from './components/Recipe';

export const AdminRoutes = () => {
  return (
    <div className="container bg-neutral rounded-box">
      <Navbar />
      <Routes>
        <Route path="/admin/users" element={<Users />}></Route>
        <Route path="/admin/recipes" element={<Recipes />}></Route>
        <Route path="/admin/recipes/:recipeName" element={<Recipe />}></Route>
      </Routes>
    </div>
  );
};
