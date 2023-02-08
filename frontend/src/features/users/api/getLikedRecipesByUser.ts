import axios, * as others from 'axios';


export const fetchLikedRecipes = async (id:number) => {
    const res = await axios.get(`https://localhost:7161/api/users/${id}/liked`);
    return res.data;
};