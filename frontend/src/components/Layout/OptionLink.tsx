import React from "react";
import { Link } from "react-router-dom";
import { API_URL } from "@/config";

export const OptionLink = ({text, to, isLogout, setUsername, setIsAdmin } :
                               { text : string,
                                   to : string,
                                   isLogout : boolean,
                                   setUsername? : React.Dispatch<React.SetStateAction<string>>,
                                   setIsAdmin? : React.Dispatch<React.SetStateAction<boolean>> }) => {
    const logout = async () => {
        await fetch(API_URL + "/Auth/Logout", {
            method: "POST",
            headers: {"Content-type": "application/json"},
            credentials: "include",
        });
        if (setUsername != undefined) setUsername("");
        if (setIsAdmin != undefined) setIsAdmin(false);
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