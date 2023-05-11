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

      if (!response.ok) {
        setHideErrorMsg(false);
        setErrorMsg("Invalid credentials!");
      }
      else {
        sessionStorage.setItem("username", result.username);
        sessionStorage.setItem("isAdmin", result.isAdmin);
        setLoggedInUsername(result.username);
        setIsAdmin(result.isAdmin);

        navigate("/");
      }
    }
    else {
      setHideErrorMsg(false);
      if (username == "" || password == "") setErrorMsg("Every field is required!");
      else setErrorMsg("Username is too short!");
    }
  }

  const googleLogin = async (e : SyntheticEvent) => {
    e.preventDefault();

    console.log("TODO");
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
                {/* <div className="mt-2">
                  <button
                      className="btn w-full text-white bg-[#4285F4] border-[#4285F4] hover:border-[#4285F4]/90 hover:bg-[#4285F4]/90 focus:ring-4 focus:outline-none focus:ring-[#4285F4]/50 font-medium rounded-inherit text-sm px-5 py-2.5 text-center inline-flex items-center dark:focus:ring-[#4285F4]/55"
                      onClick={googleLogin}>
                    <svg
                        className="w-4 h-4 mr-2 -ml-1"
                        aria-hidden="true"
                        focusable="false"
                        data-prefix="fab"
                        data-icon="google"
                        role="img"
                        xmlns="http://www.w3.org/2000/svg"
                        viewBox="0 0 488 512">
                      <path fill="currentColor" d="M488 261.8C488 403.3 391.1 504 248 504 110.8 504 0 393.2 0 256S110.8 8 248 8c66.8 0 123 24.5 166.3 64.9l-67.5 64.9C258.5 52.6 94.3 116.6 94.3 256c0 86.5 69.1 156.6 153.7 156.6 98.2 0 135-70.4 140.8-106.9H248v-85.3h236.1c2.3 12.7 3.9 24.9 3.9 41.4z"></path>
                    </svg>
                    Sign in with Google
                  </button>
                </div> */}
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
