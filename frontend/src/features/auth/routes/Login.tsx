import React, { SyntheticEvent, useState } from 'react';
import { useNavigate } from "react-router-dom";
import { API_URL } from "@/config";
import { RequiredStar } from "@/components/Form/RequiredStar";


export const Login = () => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [cred, setCred] = useState(true);
  const navigate = useNavigate();

  const submit = async (e: SyntheticEvent) => {
    e.preventDefault();

    const response = await fetch(API_URL + "/Auth/Login", {
      method: "POST",
      headers: {"Content-type": "application/json"},
      credentials: "include",
      body: JSON.stringify({
        username,
        password
      })
    });
    const result = await response.json();

    sessionStorage.setItem("username", result.username);

    if (result.hasOwnProperty("message")) setCred(false);
    else navigate("/");
    location.reload();
  }

  return (
    <form onSubmit={submit}>
      <div className="sm:container mx-auto">
        <div className="hero-content flex-col lg:flex-row-reverse mx-auto">
          <div className="card flex-shrink-0 w-full max-w-sm shadow-2xl bg-base-100">
            <div className="card-body">
              <h1 className="text-5xl font-bold">Login</h1>
                <div className="form-control">
                  <label className="label">
                    <span className="label-text">Username<RequiredStar /></span>
                  </label>
                  <input name="username" type="text" placeholder="Username" className="input input-bordered" onChange={e => setUsername(e.target.value)} required />
                </div>
                <div className="form-control">
                  <label className="label">
                    <span className="label-text">Password<RequiredStar /></span>
                  </label>
                  <input name="password" type="password" placeholder="Password" className="input input-bordered" onChange={e => setPassword(e.target.value)} required />
                  <label className="label">
                    <a href="src/features/auth/components#" className="label-text-alt link link-hover">
                      Forgot password?
                    </a>
                  </label>
                </div>
                <div className="form-control mt-6">
                  <button type="submit" className="btn btn-primary">Login</button>
                </div>
              <div id="cred-alert" className="mt-4 alert alert-error shadow-lg justify-center text-xl font-bold" hidden={cred}>
                  <span className="">Invalid credentials!</span>
              </div>
            </div>
          </div>
        </div>
      </div>
    </form>
  );
};
