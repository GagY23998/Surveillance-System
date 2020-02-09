import React, { useEffect } from 'react';
import { Route,Switch,withRouter } from "react-router-dom";
import Header from "../containers/Header/Header";
import AuthRoute from '../hoc/AuthRoute';
import ArchiveContent from "./../components/Archive/ArchiveContent";
import Home from './Home/Home';
const MainForm = (props) => {

    return (<React.Fragment>
        <Header navigationProps={[{ name: "Home", execute: null }, { name: "Archives" }, {
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
        </React.Fragment>);
}


export default withRouter(MainForm);