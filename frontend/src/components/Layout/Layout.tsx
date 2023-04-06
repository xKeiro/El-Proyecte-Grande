import { Footer } from "./Footer";
import { NavBar } from "./NavBar";
import React, { Fragment } from 'react';
import { Outlet, Link } from 'react-router-dom';

export const Layout = ({ username, isAdmin, setUsername, setIsAdmin } : {
    username : string | null,
    isAdmin : boolean,
    setUsername : React.Dispatch<React.SetStateAction<string | null>>,
    setIsAdmin : React.Dispatch<React.SetStateAction<boolean>> }) => {
    return (
        <div>
            <NavBar isAdmin={isAdmin} username={username} setIsAdmin={setIsAdmin} setUsername={setUsername} />
            <Outlet />
            <Footer />
        </div>
    )
}