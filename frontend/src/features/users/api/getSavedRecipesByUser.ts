import axios, * as others from 'axios';
import { API_URL } from '@/config';


export const fetchSavedRecipes = async (id:string) => {
    const res = await axios.get(`${API_URL}/users/${id}/saved`);
    return res.data;
};