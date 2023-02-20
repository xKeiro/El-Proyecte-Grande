import { Route, Routes } from 'react-router-dom';
import { Users } from '@/features/admin/routes/Users';
import { Recipes } from '@/features/admin/routes/Recipes';
import { Recipe } from '@/features/recipes/routes/Recipe';

export const AdminRoutes = () => {
    return (
        <div className="container bg-neutral rounded-box grid grid-cols-1 mx-auto shadow-2xl">
            <Routes>
                <Route path="/admin/users" element={<Users />}></Route>
                <Route path="/admin/recipes" element={<Recipes />}></Route>
                <Route path="/admin/recipes/:id" element={<Recipe />}></Route>
            </Routes>
        </div>
    );
};