import axios, * as others from 'axios';
import { API_URL } from '@/config';

export const fetchLikedRecipes = async (id:string) => {
    const res = await axios.get(`${API_URL}/users/${id}/liked`);
    return res.data;
};