import React, { SyntheticEvent, useState } from "react";
import { Navigate, useNavigate } from "react-router-dom";
import { RequiredStar } from "@/components/Form/RequiredStar";
import { API_URL } from "@/config";


export const Register = ({ loggedInUsername } : { loggedInUsername : string | null }) => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [emailAddress, setEmailAddress] = useState("");
    const [errorMsg, setErrorMsg] = useState("");
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

    const validateEmailAddress = () => {
        const emailRegex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
        return emailRegex.test(emailAddress);
    }

    const submit = async (e: SyntheticEvent) => {
        e.preventDefault();

        // const validPw = validatePw();
        if (username.length >= 2 && password != "" && validateEmailAddress()) {
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
                console.log(result);
                setHideErrorMsg(false);
                if (result.usernameMsg != "ok") setErrorMsg(result.usernameMsg);
                else setErrorMsg(result.emailMsg);
            }
            else navigate("/login");
        }
        else {
            setHideErrorMsg(false);
            if (username == "" || password == "" || emailAddress == "") setErrorMsg("A required field is empty!");
            else if (username.length < 2) setErrorMsg("Username is too short!");
            else setErrorMsg("Invalid email address pattern!");
        }
    }

    if (loggedInUsername == null) return (
        <form>
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
                                <button className="btn btn-primary" onClick={submit}>Register</button>
                            </div>
                            <div id="error-box" className="mt-4 alert alert-error shadow-lg justify-center text-lg font-bold" hidden={hideErrorMsg}>
                                <span>{errorMsg}</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    );
    return (<Navigate to="/" />);
}