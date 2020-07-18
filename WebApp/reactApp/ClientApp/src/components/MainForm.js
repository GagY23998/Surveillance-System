import React, { useEffect } from 'react';
import { Route,Switch,withRouter,Redirect } from "react-router-dom";
import Header from "../containers/Header/Header";
import ArchiveContent from "./../components/Archive/ArchiveContent";
import Home from './Home/Home';
const MainForm = (props) => {

    return (<React.Fragment>
        {localStorage["token"] ?
            (<React.Fragment>
            <Header navigationProps={[{ name: "Home" }, { name: "Archives" }, {
            name: "Logout",
            execute: e => {
                localStorage.clear();
                props.history.push("/signin");
            }
        }]} />
        <Switch>
            <Route path="/archives" component={ArchiveContent} />
            <Route path="/" component={Home} />
        </Switch>
                </React.Fragment>)
        :<Redirect to="/signin" />}
        </React.Fragment>);
}


export default withRouter(MainForm);