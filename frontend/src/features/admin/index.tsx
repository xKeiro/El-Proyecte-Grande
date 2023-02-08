import './adminPage.css'
import {Route, Routes} from "react-router-dom";
import MainPage from "./components/MainPage";
import Users from "./components/Users";
import Navbar from "./components/Navbar";
import Recipes from "./components/Recipes";
import Recipe from "./components/Recipe";

const AdminPage = () => {
    return (
        <div className="container bg-neutral rounded-box">
            <Navbar />
            <Routes>
                <Route path='/' element={<MainPage />}></Route>
                <Route path='/Users' element={<Users />}></Route>
                <Route path='/Recipes' element={<Recipes />}></Route>
                <Route path='/Recipes/:recipeName' element={<Recipe />}></Route>
            </Routes>
        </div>
    )
}

export default AdminPage