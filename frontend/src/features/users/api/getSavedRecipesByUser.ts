import axios, * as others from 'axios';


export const fetchSavedRecipes = async (id:string) => {
    const res = await axios.get(`https://localhost:7161/api/users/${id}/saved`);
    return res.data;
};