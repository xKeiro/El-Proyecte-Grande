import { Footer } from "./Footer";
import { NavBar } from "./NavBar";
import { Fragment } from 'react';
import { Outlet, Link } from 'react-router-dom';

export const Layout = () => {
    return (
        <div>
            <NavBar />
            <Outlet />
            <Footer />
        </div>
    )
}