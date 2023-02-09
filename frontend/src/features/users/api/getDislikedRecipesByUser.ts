import axios, * as others from 'axios';
import { API_URL } from '@/config';


export const fetchDislikedRecipes = async (id:string) => {
    const res = await axios.get(`${API_URL}/users/${id}/disliked`);
    return res.data;
};