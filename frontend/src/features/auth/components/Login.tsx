import React, { useState } from 'react';
import {RequiredStar} from "@/components/Form/RequiredStar";

const Login = () => {
  const [isShown, setIsSHown] = useState(false);
  const handleLogin = () => {
    window.location.href = '/';
  };

  return (
    <div className="sm:container mx-auto">
      <div className="hero-content flex-col lg:flex-row-reverse mx-auto">
        <div className="card flex-shrink-0 w-full max-w-sm shadow-2xl bg-base-100">
          <div className="card-body">
            <h1 className="text-5xl font-bold">Login</h1>
            <div className="form-control">
              <label className="label">
                <span className="label-text">Username<RequiredStar /></span>
              </label>
              <input type="text" placeholder="Username" className="input input-bordered" />
            </div>
            <div className="form-control">
              <label className="label">
                <span className="label-text">Password<RequiredStar /></span>
              </label>
              <input type="password" placeholder="Password" className="input input-bordered" />
              <label className="label">
                <a href="#" className="label-text-alt link link-hover">
                  Forgot password?
                </a>
              </label>
            </div>
            <div className="form-control mt-6">
              <button className="btn btn-primary" onClick={handleLogin}>
                Login
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Login;
