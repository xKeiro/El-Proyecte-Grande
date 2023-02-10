import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';
import SavedRecipes from './SavedRecipes';
import LikedRecipes from './LikedRecipes';
import DislikedRecipes from './DislikedRecipes';
import {API_URL} from "@/config";

const User = () => {

    const [user, setUser] = useState<any>({});
    const { id } = useParams();

    //fetch the user
    useEffect(() => {
        const fetchUsers = async () => {
            const res = await axios.get(`${API_URL}/users/${id}`);
            setUser(res.data);
        };
        fetchUsers();

    }, [id]);

    return (
            <div className="min-h-screen flex  justify-center">
                <div className="w-2/5 mx-auto p-4 flex flex-col">
                    <div className="flex items-center justify-center bg-base-300 rounded p-4">
                        <div className="text-center">
                            <h1 className="text-2xl font-medium"><u>{user.username}</u></h1>
                            <h3><b>{user.isAdmin ? "ADMIN" : ""}</b></h3>
                            <h5 className="text-md"><i>{user.emailAddress}</i></h5>
                        </div>
                    </div>
                    <div className="mt-4 grid grid-columns-1 gap-2">
                        <SavedRecipes />
                        <LikedRecipes />
                        <DislikedRecipes />
                    </div>
                </div>
            </div>
    )
}

export default User;

