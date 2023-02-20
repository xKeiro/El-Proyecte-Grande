import axios, * as others from 'axios';
import { API_URL } from '@/config';

export abstract class UsersApi{

    public static async getAllusers() {
        const res = await axios.get(`${API_URL}/users`);
        return await res.data;    
    }
    
    public static async getUserById(id: number) {
        const res = await axios.get(`${API_URL}/users/${id}`);
        return await res.data;    
    }

    public static async getDislikedRecipes(id: number){
        const res = await axios.get(`${API_URL}/users/${id}/disliked`);
        return res.data;
    };

    public static async getLikedRecipes(id: number){
        const res = await axios.get(`${API_URL}/users/${id}/liked`);
        return res.data;
    };

    public static async getSavedRecipes(id: number){
        const res = await axios.get(`${API_URL}/users/${id}/saved`);
        return res.data;
    };
}


