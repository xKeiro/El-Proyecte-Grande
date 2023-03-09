import axios from 'axios';
import { API_URL } from '@/config';

export abstract class UsersApi{

    public static async getAllusers() {
        const res = await axios.get(`${API_URL}/users`, { withCredentials : true });
        return await res.data;    
    }
    
    public static async getUserById(id: number) {
        const res = await axios.get(`${API_URL}/users/${id}`, { withCredentials : true });
        return await res.data;    
    }

    public static async getDislikedRecipes(id: number){
        const res = await axios.get(`${API_URL}/users/${id}/disliked`, { withCredentials : true });
        return res.data;
    };

    public static async getLikedRecipes(id: number){
        const res = await axios.get(`${API_URL}/users/${id}/liked`, { withCredentials : true });
        return res.data;
    };

    public static async getSavedRecipes(id: number){
        const res = await axios.get(`${API_URL}/users/${id}/saved`, { withCredentials : true });
        return res.data;
    };
}


