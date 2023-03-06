import React from 'react';
import {RequiredStar} from "@/components/Form/RequiredStar";
import { API_URL } from "@/config";


export const Login = () => {
  return (
    <form action={API_URL + "/Auth/Login"} method="post">
      <div className="sm:container mx-auto">
        <div className="hero-content flex-col lg:flex-row-reverse mx-auto">
          <div className="card flex-shrink-0 w-full max-w-sm shadow-2xl bg-base-100">
            <div className="card-body">
              <h1 className="text-5xl font-bold">Login</h1>
                <div className="form-control">
                  <label className="label">
                    <span className="label-text">Username<RequiredStar /></span>
                  </label>
                  <input name="username" type="text" placeholder="Username" className="input input-bordered" required />
                </div>
                <div className="form-control">
                  <label className="label">
                    <span className="label-text">Password<RequiredStar /></span>
                  </label>
                  <input name="password" type="password" placeholder="Password" className="input input-bordered" required />
                  <label className="label">
                    <a href="src/features/auth/components#" className="label-text-alt link link-hover">
                      Forgot password?
                    </a>
                  </label>
                </div>
                <div className="form-control mt-6">
                  <button type="submit" className="btn btn-primary">Login</button>
                </div>
            </div>
          </div>
        </div>
      </div>
    </form>
  );
};
