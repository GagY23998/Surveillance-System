import React, { useState,useEffect,useContext } from 'react';
import Header from "./containers/Header/Header";
import { Route, Switch,Redirect,withRouter,useHistory } from "react-router-dom";
import MainForm from "./components/MainForm";
import './custom.css'
import AuthService from "./services/AuthService";
import AuthRoute from './hoc/AuthRoute';
import SignIn from "./components/Authentication/SignIn";
import UserContext from './context/UserContext';




const App = (props)=> {    

    const [token, setToken] = useState("");

    useEffect(() => {
        if (localStorage["token"]) {
            setToken(localStorage["token"]);
        }
    },[]);

    const signIn = (e) => {
        e.preventDefault();
        const signInData = {
            UserName: e.target[0].value,
            Password: e.target[1].value
        };
        const configHeaders = {
            "content-type": "application/json; charset=utf-8",
            "Accept": "application/json"
        };
        AuthService.axios.post("/token",
            null,
            {
                data: signInData,
                headers: configHeaders
            }).then(data => {
                console.log(data);
                localStorage.setItem("token", data.data.token);
                let result = data.data.userRoles.reduce((prevVal,element)=>prevVal+element.role.name+",","");
                console.log(result);
                localStorage.setItem("roles", result);
                props.history.push("/");
            }).catch(err => {
                localStorage.clear();
            });
            
    };


    return (
        <UserContext.Provider value={token}>
          <React.Fragment>
                  <Switch>
                    <Route path="/signin" render={(props) => <SignIn signInHandler={signIn} {...props} />} />
                    <Route path="/" render={(props) => <MainForm {...props} />}/>
                  </Switch>     
        </React.Fragment>  
        </UserContext.Provider>
    );
}

export default withRouter(App);
        //<Route exact path='/' component={Home} />
        //<Route path='/counter' component={Counter} />
        //<Route path='/fetch-data' component={FetchData} />