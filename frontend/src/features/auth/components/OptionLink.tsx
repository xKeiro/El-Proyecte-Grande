import React from "react";
import { Link } from "react-router-dom";
import { API_URL } from "@/config";

export const OptionLink = ({ text, to, isLogout } : { text : string, to : string, isLogout : boolean }) => {
    const logout = async () => {
        await fetch(API_URL + "/Auth/Logout", {
            method: "POST",
            headers: {"Content-type": "application/json"},
            credentials: "include",
        });
        sessionStorage.clear();
        location.reload();
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