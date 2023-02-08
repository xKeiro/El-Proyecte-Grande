import axios from "axios";

export async function getUsers() {
     const res = await axios.get(`https://localhost:44329/api/users`);
     return res.data
}