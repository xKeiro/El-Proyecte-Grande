import { RecipesRoutes } from "@/features/recipes/";
import { UsersRoutes } from '@/features/users/';
import { AdminRoutes } from "@/features/admin";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Layout } from "./components/Layout/Layout";

export const App = () =>{
  return (
    <BrowserRouter>
      <Layout />
          <RecipesRoutes/>
          <UsersRoutes/>
          <AdminRoutes/>
    </BrowserRouter>
  )
}
