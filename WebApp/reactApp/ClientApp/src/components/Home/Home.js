import React, { useState,useEffect } from "react";
import "./Home.css";
import AxiosInstance from "../../services/AuthService";
import axios from "axios";
import Table from "../Archive/Table";
const Home = (props) => {

    const [visits, setVisits] = useState({});
    

    //useEffect(() => {
    //    AxiosInstance.axios.get("/archive/visits", { headers: {"authorization":"Bearer " + localStorage["token"]}}).then(data => setVisits(data.data)).catch(err => console.log(err));
    //    console.log(visits);
    //});
    useEffect(() => {
        axios.get("https://localhost:44332/api/archive/visits", { headers: { "authorization": "Bearer " + localStorage["token"] } })
        .then(data => setVisits(data.data)).catch(err => props.history.push("/signin"));
    },[]);
    return (
        <div style={{height:"100%"}}>
            <div className="myGrid">
                <div style={{overflowY:"auto"}}>
                    <Table headers="Today Visits" tableData={visits.visitsToday}/>
                </div>
                <div style={{ overflowY: "auto" }}>
                    <Table headers="Monthly Visits" tableData={visits.visitsMonth}/>
                </div>
                <div style={{gridColumn:"1 / span 2"}}>
                    <h3 style={{color:"Black"}} >Total Visits/Departures: {visits.totalVisits}</h3>
                </div>
            </div>
        </div>
        )
}


export default Home;