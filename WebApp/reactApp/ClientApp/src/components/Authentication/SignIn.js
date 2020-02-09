import React from "react";
import "./SignIn.css";
const SignIn = ({ signInHandler,...props}) => {

    return (
        <div className="SignIn">
            <form onSubmit={signInHandler}>
                    
                    <h3>House Protection System</h3>
                <div>
                    <label>Username:</label>
                    <span><input type="text" placeholder="Enter username" /></span>
                </div>
                <div>
                    <label>Password:</label>
                    <span><input type="password" placeholder="Enter password..." /></span>
                </div>
                <div>
                    <button type="submit">Sign In</button>
                </div>
                
            </form>
        </div>
        );


};


export default SignIn;