import axios from 'axios';
import { API_URL } from '@/config';
import { userRecipeStatusSchema, UserRecipeStatus, TUserRecipeAddNew } from '../types';

export abstract class UsersApi {

    public static async getAllUser() {
        const res = await axios.get(`${API_URL}/users`, { withCredentials : true });
        return await res.data;
    }

    public static async getUserById(id: number) {
        const res = await axios.get(`${API_URL}/users/${id}`, { withCredentials: true });
        return await res.data;
    }

    public static async getUserProfile() {
        const res = await axios.get(`${API_URL}/users/userprofile`, { withCredentials : true });
        return await res.data;
    }

    public static async getDislikedRecipes(id: number) {
        const res = await axios.get(`${API_URL}/users/${id}/disliked`, { withCredentials : true });
        return res.data;
    };

    public static async getLikedRecipes(id: number) {
        const res = await axios.get(`${API_URL}/users/${id}/liked`, { withCredentials: true });
        return res.data;
    };

    public static async getSavedRecipes(id: number) {
        const res = await axios.get(`${API_URL}/users/${id}/saved`, { withCredentials: true });
        return res.data;
    };
    public static async getUserRecipeStatus(recipeId: number) {
        const res = await axios.get(`${API_URL}/users/me/recipes/${recipeId}/status`, { withCredentials: true });
        const result = userRecipeStatusSchema.safeParse(res.data);
        if (result.success) {
            return res.data;
        } else {
            console.log(result.error.issues);
        }
    };
    public static async addUserRecipeStatus(recipeId: number, status: UserRecipeStatus) {
        const userRecipeAddNew: TUserRecipeAddNew = {
            recipeStatus: status
        }
        const res = await axios.post(`${API_URL}/users/me/recipes/${recipeId}`, userRecipeAddNew, { withCredentials: true });
        if (res.status !== 201) {
            console.log(res.data);
        }
    }
    public static async deleteUserRecipeStatus(recipeId: number) {
        const res = await axios.delete(`${API_URL}/users/me/recipes/${recipeId}`, { withCredentials: true });
        if (res.status !== 200) {
            console.log(res.data);
        }
    }
}


