import axios from "axios";
import { API_URL } from "@/config";

export async function getUsers() {
     const res = await axios.get(`${API_URL}/users`, { withCredentials : true });
     return res.data
}