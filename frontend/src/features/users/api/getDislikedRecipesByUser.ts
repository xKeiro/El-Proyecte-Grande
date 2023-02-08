import axios, * as others from 'axios';


export const fetchDislikedRecipes = async (id:string) => {
    const res = await axios.get(`https://localhost:7161/api/users/${id}/disliked`);
    return res.data;
};