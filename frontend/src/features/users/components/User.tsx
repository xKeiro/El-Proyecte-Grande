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
        <div>
            <div className="card-body">
                <h2 className="card-title">Name: {user.username}</h2>
                <p>Email: {user.emailAddress}</p>
                <SavedRecipes />
                <LikedRecipes />
                <DislikedRecipes/>
                
            </div>
        </div>
    )
}

export default User;
