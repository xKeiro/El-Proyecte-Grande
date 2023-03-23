import { Route, Routes } from 'react-router-dom';
import { Users } from '@/features/admin/routes/Users';
import { Recipes } from '@/features/admin/routes/Recipes';
import { Unauthorized } from "@/features/auth/routes/Unauthorized";
import { EditRecipe } from "@/features/admin/routes/EditRecipe";
import { AdminRecipe } from "@/features/admin/routes/AdminRecipe";
import { RecipeProperties } from "@/features/admin/routes/RecipeProperties";
import { AddRecipe } from './AddRecipe';

export const AdminRoutes = ({ isAdmin, username } : { isAdmin : boolean, username : string | null }) => {
    return (
        <div className="container bg-base-100 rounded-box grid grid-cols-1 mx-auto shadow-2xl">
            <Routes>
                <Route path="/admin/users" element={<Users isAdmin={isAdmin} />}></Route>
                <Route path="/admin/recipes" element={<Recipes isAdmin={isAdmin} />}></Route>
                <Route path="/admin/recipes/:id" element={<AdminRecipe isAdmin={isAdmin} username={username} />}></Route>
                <Route path="/admin/recipes/:id/edit" element={<EditRecipe isAdmin={isAdmin} />}></Route>
                <Route path="/admin/recipe-properties" element={<RecipeProperties isAdmin={isAdmin} />}></Route>
                <Route path="/admin/recipes/add" element={<AddRecipe isAdmin={isAdmin}/>}></Route>
                <Route path="/unauthorized" element={<Unauthorized />}></Route>
            </Routes>
        </div>
    );
};