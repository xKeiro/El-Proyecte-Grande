import React from "react";
import {RequiredStar} from "@/components/Form/RequiredStar";
import { API_URL } from "@/config";


export const Register = () => {
    return (
        <form action={API_URL + "/Auth/Register"} method="post">
            <div className='sm:container mx-auto'>
                <div className="hero-content flex-col lg:flex-row-reverse mx-auto">
                    <div className="card flex-shrink-0 w-full max-w-xl shadow-2xl bg-base-100">
                        <div className="card-body">
                            <h1 className="text-5xl font-bold">Register</h1>
                            <div className="form-control">
                                <label className="label">
                                    <span className="label-text">Username<RequiredStar /></span>
                                </label>
                                <input type="text" placeholder="Username" className="input input-bordered" required />
                            </div>
                            <div className="form-control">
                                <label className="label">
                                    <span className="label-text">First Name</span>
                                </label>
                                <input type="text" placeholder="First name" className="input input-bordered" />
                            </div>
                            <div className="form-control">
                                <label className="label">
                                    <span className="label-text">Last Name</span>
                                </label>
                                <input type="text" placeholder="Last name" className="input input-bordered" />
                            </div>
                            <div className="form-control">
                                <label className="label">
                                    <span className="label-text">Email<RequiredStar /></span>
                                </label>
                                <input type="text" placeholder="Email" className="input input-bordered" required />
                            </div>
                            <div className="form-control">
                                <label className="label">
                                    <span className="label-text">Password<RequiredStar /></span>
                                </label>
                                <input type="password" placeholder="Password" className="input input-bordered" required />
                            </div>
                            <div className="form-control">
                                <label className="label">
                                    <span className="label-text">Confirm Password<RequiredStar /></span>
                                </label>
                                <input type="password" placeholder="Password" className="input input-bordered" required />
                            </div>
                            <div className="form-control mt-6">
                                <button type="submit" className="btn btn-primary">Register</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    );
}