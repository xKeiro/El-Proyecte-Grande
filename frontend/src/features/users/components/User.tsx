import React, { useEffect, useState } from 'react';
import { Navigate, useParams } from 'react-router-dom';
import { UsersApi } from '../api/UsersApi';
import SavedRecipes from './SavedRecipes';
import LikedRecipes from './LikedRecipes';
import DislikedRecipes from './DislikedRecipes';
import { TUser } from '../types';
import { userSchema } from '../types';

export const User = ({ isAdmin } : { isAdmin : boolean }) => {

    const [user, setUser] = useState<TUser>();
    const { id } = useParams();

    //fetch the user
    useEffect(() => {
        const fetchUsers = async () => {
            if (id) {
                const data = await UsersApi.getUserById(parseInt(id));
                const result = userSchema.safeParse(data)
                if(result.success){
                    setUser(data);
                }
                else{
                    console.log(result.error.issues)
                }
            }
        };
        fetchUsers();

    }, [id]);

    if (isAdmin) return (
        <div className="min-h-screen flex  justify-center">
            <div className="w-2/5 mx-auto p-4 flex flex-col">
                <div className="flex items-center justify-center bg-base-300 rounded p-4">
                    <div className="text-center">
                        <h1 className="text-2xl font-medium"><u>{user?.username}</u></h1>
                        <h3><b>{user?.isAdmin ? "ADMIN" : ""}</b></h3>
                        <h5 className="text-md"><i>{user?.emailAddress}</i></h5>
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
    return <Navigate to="/unauthorized" />
}
