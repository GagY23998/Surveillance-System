import React, { useState } from "react";
import "./Filter.css";
import AxiosInstance from "./../../services/AuthService";

const Filter = ({ searchArchiveHandler },...props) => {


    return (<div>
        <button id="btnForm">>></button>
        <form onSubmit={searchArchiveHandler} id="theForm" className="form-inline" style={{padding:"5px 0 5px 0"}}>
            <div className="row formRow" >

                <label className="col-form-label">First Name: </label>
                <input className="form-control" type="text" name="FirstName" />

                <label className="col-form-label">Last Name: </label>
                <input className="form-control" type="text" name="LastName" />
            </div>
            <div className="row formRow">

                <label className="col-form-label">Start Date: </label>
                <input className="form-control" type="date" name="FromDate" />

                <label className="col-form-label">End Date: </label>
                <input className="form-control" type="date" name="ToDate" />

            </div>
            <div className="row formRow col-sm-3" >
                <label>Entered: </label>
                <input className="formRow" type="checkbox" name="Entered" />
                <label>Left: </label>
                <input className="formRow" type="checkbox" name="Left" />
            <input className="form-control" id="myButton" type="submit" value="Search" />
            </div>
            </form>
        </div>)

}


export default Filter;