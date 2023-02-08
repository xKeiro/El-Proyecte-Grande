import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';
import SavedRecipes from './SavedRecipes';
import LikedRecipes from './LikedRecipes';
import DislikedRecipes from './DislikedRecipes';

const User = () => {

    const [user, setUser] = useState<any>({});
    const { id } = useParams();

    //fetch the user
    useEffect(() => {
        const fetchUsers = async () => {
            const res = await axios.get(`https://localhost:7161/api/users/${id}`);
            setUser(res.data);
            console.log(res.data);
        };
        fetchUsers();

    }, [id]);

    return (
        <div className="min-h-screen flex items-center justify-center">
            <div className="w-1/2 mx-auto p-4 flex flex-col">
                <div className="flex items-center justify-start bg-base-300 shadow rounded p-4">
                    <div className="text-center">
                        <h1 className="text-2xl font-medium text-primary">{user.username}</h1>
                        <small className="text-xs text-info">{user.emailAddress}</small>
                    </div>
                </div>
                <div className="mt-4">
                    <SavedRecipes />
                    <LikedRecipes />
                    <DislikedRecipes />
                </div>
            </div>
        </div>
    )
}

export default User;

