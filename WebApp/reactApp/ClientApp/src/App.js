import React, { useState,useEffect,useContext } from 'react';
import { Route, Switch,Redirect,withRouter,useHistory } from "react-router-dom";
import MainForm from "./components/MainForm";
import './custom.css'
import AuthService from "./services/AuthService";
import SignIn from "./components/Authentication/SignIn";




const App = (props)=> {    

    const [token, setToken] = useState("");

    useEffect(() => {
        if (localStorage["token"]) {
            setToken(localStorage["token"]);
        }
        return () => { console.log("Cleaning storage"); localStorage.clear(); };
    }, []);
    const history = useHistory();

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
        if (signInData.UserName && signInData.Password) {

            AuthService.post("/token",
                null,
                {
                    data: signInData,
                    headers: configHeaders
                }).then(data => {
                    console.log(data);
                    localStorage.setItem("token", data.data.token);
                    let result = data.data.userRoles.reduce((prevVal, element) => prevVal + element.role.name + ",", "");
                    console.log(result);
                    localStorage.setItem("roles", result);
                    //if (localStorage.getItem("history") === "/signin"){
                    //history.push("/");
                    //}else {
                    //    history.push(localStorage.getItem("history"));
                    //}
                    history.push("/");
                }).catch(err => {
                    localStorage.clear();
                    history.push("/");
                });

        }

            
    };


    return (
          <React.Fragment>
                  <Switch>
                    <Route path="/signin" render={(props) => <SignIn signInHandler={signIn} {...props} />} />
                    <Route path="/" render={(props) => <MainForm {...props} />}/>
                  </Switch>     
        </React.Fragment>  
    );
}

export default withRouter(App);
        //<Route exact path='/' component={Home} />
        //<Route path='/counter' component={Counter} />
        //<Route path='/fetch-data' component={FetchData} />