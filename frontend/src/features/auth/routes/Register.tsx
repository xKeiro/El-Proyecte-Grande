import React, {SyntheticEvent, useState} from "react";
import {Navigate, useNavigate} from "react-router-dom";
import { RequiredStar } from "@/components/Form/RequiredStar";
import { API_URL } from "@/config";


export const Register = ({ loggedInUsername } : { loggedInUsername : string | null }) => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [emailAddress, setEmailAddress] = useState("");
    const [usernameMsg, setUsernameMsg] = useState("");
    const [emailMsg, setEmailMsg] = useState("");
    const [hideErrorMsg, setHideErrorMsg] = useState(true);
    // const [confirmPassword, setConfirmPassword] = useState("");

    const navigate = useNavigate();

    // const validatePw = () => {
    //     const pwField = document.getElementById("password") as HTMLInputElement;
    //     const confirmPwField = document.getElementById("confirm-password") as HTMLInputElement;
    //
    //     if (pwField.value != confirmPwField.value) {
    //         confirmPwField.setCustomValidity("Passwords doesn't match!");
    //         return false;
    //     }
    //     confirmPwField.setCustomValidity("");
    //     return true;
    // }

    const submit = async (e: SyntheticEvent) => {
        e.preventDefault();

        // const validPw = validatePw();

        const response = await fetch(API_URL + "/Auth/Register", {
            method: "POST",
            headers: {"Content-type": "application/json"},
            body: JSON.stringify({
                username,
                password,
                firstName,
                lastName,
                emailAddress
            })
        });
        const result = await response.json();

        if (!response.ok) {
            setHideErrorMsg(false);
            setUsernameMsg(result.usernameMsg);
            setEmailMsg(result.emailMsg);
        }
        else navigate("/login");
    }

    if (loggedInUsername == null) return (
        <form onSubmit={submit}>
            <div className='sm:container mx-auto'>
                <div className="hero-content flex-col lg:flex-row-reverse mx-auto">
                    <div className="card flex-shrink-0 w-full max-w-xl shadow-2xl bg-base-100">
                        <div className="card-body">
                            <h1 className="text-5xl font-bold">Register</h1>
                            <div className="form-control">
                                <label className="label">
                                    <span className="label-text">Username<RequiredStar /></span>
                                </label>
                                <input id="username" type="text" placeholder="Username"
                                       className="input input-bordered" onChange={e => setUsername(e.target.value)} required />
                            </div>
                            <div className="form-control">
                                <label className="label">
                                    <span className="label-text">First Name</span>
                                </label>
                                <input type="text" placeholder="First name"
                                       className="input input-bordered" onChange={e => setFirstName(e.target.value)} />
                            </div>
                            <div className="form-control">
                                <label className="label">
                                    <span className="label-text">Last Name</span>
                                </label>
                                <input type="text" placeholder="Last name"
                                       className="input input-bordered" onChange={e => setLastName(e.target.value)} />
                            </div>
                            <div className="form-control">
                                <label className="label">
                                    <span className="label-text">Email<RequiredStar /></span>
                                </label>
                                <input id="email" type="text" placeholder="Email"
                                       className="input input-bordered" onChange={e => setEmailAddress(e.target.value)} required />
                            </div>
                            <div className="form-control">
                                <label className="label">
                                    <span className="label-text">Password<RequiredStar /></span>
                                </label>
                                <input id="password" type="password" placeholder="Password"
                                       className="input input-bordered" onChange={e => setPassword(e.target.value)} required />
                            </div>
                            {/*<div className="form-control">*/}
                            {/*    <label className="label">*/}
                            {/*        <span className="label-text">Confirm Password<RequiredStar /></span>*/}
                            {/*    </label>*/}
                            {/*    <input id="confirm-password" type="password" placeholder="Confirm password"*/}
                            {/*           className="input input-bordered" onChange={e => setConfirmPassword(e.target.value)} required />*/}
                            {/*</div>*/}
                            <div className="form-control mt-6">
                                <button type="submit" className="btn btn-primary">Register</button>
                            </div>
                            <div id="cred-alert" className="grid grid-cols-1 mt-4 alert alert-error shadow-lg justify-center text-lg font-bold" hidden={hideErrorMsg}>
                                <span hidden={usernameMsg == "ok"}>{usernameMsg}</span>
                                <span hidden={emailMsg == "ok"}>{emailMsg}</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    );
    return (<Navigate to="/" />);
}