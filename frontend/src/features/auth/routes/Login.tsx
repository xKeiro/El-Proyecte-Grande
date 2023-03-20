import React, { SyntheticEvent, useState } from 'react';
import { Navigate, useNavigate } from "react-router-dom";
import { API_URL } from "@/config";
import { RequiredStar } from "@/components/Form/RequiredStar";


export const Login = ({ loggedInUsername, setLoggedInUsername, setIsAdmin } : {
  loggedInUsername : string | null,
  setLoggedInUsername : React.Dispatch<React.SetStateAction<string | null>>,
  setIsAdmin : React.Dispatch<React.SetStateAction<boolean>> }) => {

  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [errorMsg, setErrorMsg] = useState("");
  const [hideErrorMsg, setHideErrorMsg] = useState(true);
  const navigate = useNavigate();

  const submit = async (e: SyntheticEvent) => {
    e.preventDefault();

    if (username.length >= 2 && password != "") {
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
      sessionStorage.setItem("isAdmin", result.isAdmin);
      setLoggedInUsername(result.username);
      setIsAdmin(result.isAdmin);

      if (result.hasOwnProperty("message")) {
        setHideErrorMsg(false);
        setErrorMsg("Invalid credentials!");
      }
      else navigate("/");
    }
    else {
      setHideErrorMsg(false);
      if (username == "" || password == "") setErrorMsg("Every field is required!");
      else setErrorMsg("Username is too short!");
    }
  }

  if (loggedInUsername == null) return (
    <form>
      <div className="sm:container mx-auto">
        <div className="hero-content flex-col lg:flex-row-reverse mx-auto">
          <div className="card flex-shrink-0 w-full max-w-sm shadow-2xl bg-base-100">
            <div className="card-body">
              <h1 className="text-5xl font-bold">Login</h1>
                <div className="form-control">
                  <label className="label">
                    <span className="label-text">Username<RequiredStar /></span>
                  </label>
                  <input id="username" name="username" type="text" placeholder="Username" className="input input-bordered" onChange={e => setUsername(e.target.value)} />
                </div>
                <div className="form-control">
                  <label className="label">
                    <span className="label-text">Password<RequiredStar /></span>
                  </label>
                  <input id="password" name="password" type="password" placeholder="Password" className="input input-bordered" onChange={e => setPassword(e.target.value)} />
                  <label className="label">
                    <a href="src/features/auth/components#" className="label-text-alt link link-hover">
                      Forgot password?
                    </a>
                  </label>
                </div>
                <div className="form-control mt-6">
                  <button className="btn btn-primary" onClick={submit}>Login</button>
                </div>
              <div id="cred-alert" className="mt-4 alert alert-error shadow-lg justify-center text-lg font-bold" hidden={hideErrorMsg}>
                  <span>{errorMsg}</span>
              </div>
            </div>
          </div>
        </div>
      </div>
    </form>
  );
  return (<Navigate to="/" />)
};
