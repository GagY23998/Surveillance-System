import React, { useState,useEffect,useContext } from 'react';
import { Redirect } from 'react-router-dom';
import UserContext from '../context/UserContext';



const AuthRoute = ({ component },...props) => {
    const Component = component;

    return (
        (localStorage["token"] && localStorage["token"].length !== 0) ? <Component {...props}/> : <Redirect to="/signin" />
    );
};


export default AuthRoute;
