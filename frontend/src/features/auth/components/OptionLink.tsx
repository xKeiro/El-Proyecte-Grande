import React from "react";
import { Link } from "react-router-dom";
import { API_URL } from "@/config";

export const OptionLink = ({ text, to, isLogout, setUsername, setIsAdmin } : {
    text : string,
    to : string,
    isLogout : boolean,
    setUsername? : React.Dispatch<React.SetStateAction<string | null>>,
    setIsAdmin? : React.Dispatch<React.SetStateAction<boolean>> }) => {

    const logout = async () => {
        await fetch(API_URL + "/Auth/Logout", {
            method: "POST",
            headers: {"Content-type": "application/json"},
            credentials: "include",
        });

        if (setUsername != undefined) setUsername(null);
        if (setIsAdmin != undefined) setIsAdmin(false);
        sessionStorage.clear();
    }

    if (!isLogout) return (
         <Link to={to} className="text-xl">
            {text}
        </Link>
    );
    return (
        <Link to={to} onClick={logout} className="text-xl">
            {text}
        </Link>
    )
}