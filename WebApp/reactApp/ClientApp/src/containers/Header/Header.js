import React from "react";
import { Link } from "react-router-dom";
import AuthRoute from "../../hoc/AuthRoute";
import "./Header.css";

const Header = ({ navigationProps },...props) => {

    return (
        <div className="Header">
            <ul>
                {(navigationProps.length > 0) ? navigationProps.map((element, index) =>
                    <li key={index}><Link style={{ textDecorationStyle: "none" }} to={"/" + element.name.toLowerCase().replace(/\s/g, "")} onClick={(element.execute)?element.execute:null}>{element.name}</Link></li>
                    ) : null
                }                
                
            </ul>
        </div>
    );

};

export default Header;