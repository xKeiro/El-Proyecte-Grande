import { Route, Routes } from 'react-router-dom';
import { Users } from '@/features/admin/routes/Users';
import { Recipes } from '@/features/admin/routes/Recipes';
import { Unauthorized } from "@/features/auth/routes/Unauthorized";
import { EditRecipe } from "@/features/admin/routes/EditRecipe";
import { AdminRecipe } from "@/features/admin/routes/AdminRecipe";

export const AdminRoutes = () => {
    return (
        <div className="container bg-base-100 rounded-box grid grid-cols-1 mx-auto shadow-2xl">
            <Routes>
                <Route path="/admin/users" element={<Users />}></Route>
                <Route path="/admin/recipes" element={<Recipes />}></Route>
                <Route path="/admin/recipes/:id" element={<AdminRecipe />}></Route>
                <Route path="/admin/recipes/:id/edit" element={<EditRecipe />}></Route>
                <Route path="/unauthorized" element={<Unauthorized />}></Route>
            </Routes>
        </div>
    );
};