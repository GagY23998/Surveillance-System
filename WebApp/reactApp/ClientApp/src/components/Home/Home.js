import React, { useState,useEffect } from "react";
import "./Home.css";
import AxiosInstance from "../../services/AuthService";
import axios from "axios";
import * as signalR from "@aspnet/signalr";
import Table from "../Archive/Table";
const Home = (props) => {

    const [visits, setVisits] = useState({
        visitsToday: [],
        visitsMonth: []        
    });
    const [currentEntry, setCurrentEntry] = useState([]);
    useEffect(() => {
        const myHubConnection = new signalR.HubConnectionBuilder()
            .withUrl("/archivehub")
            .configureLogging(signalR.LogLevel.Information)
            .build();
        myHubConnection.serverTimeoutInMilliseconds = 100000;

        myHubConnection.start(() => console.log("WebSocket started")).catch(err => console.log(err));

        myHubConnection.on("RecieveMessage", (data) => {
                let newEnter = [...currentEntry];
                newEnter.push(data);
                console.log(newEnter);
                setCurrentEntry(newEnter);
            
        });
        myHubConnection.on("UpdateMessage", (data) => {
            console.log(data);
            let index = currentEntry.findIndex(el => el.id === data.id);
            let newArray = [...currentEntry];
            newArray.splice(index, 1);
            setCurrentEntry(newArray);
        });
        return () => myHubConnection.stop();
    }, []);

    useEffect(() => {
        axios.get("https://localhost:44332/api/archive/currentEntries", { headers: { "authorization": "Bearer " + localStorage["token"]} })
            .then((data) => setCurrentEntry(data.data)).catch(err => console.log("Error occured"));
        return () => setVisits({ visitsMonth: [], visitsToday: [] });
    }, []);

    useEffect(() => {
        axios.get("https://localhost:44332/api/archive/visits", { headers: { "authorization": "Bearer " + localStorage["token"] } })
            .then(data =>  setVisits(data.data)).catch(err=>props.history.push("/signin"));
    }, []);
    return (
        <div style={{height:"100%"}}>
            <div className="myGrid">
                <div style={{overflowY:"auto"}}>
                    <Table headers="Today Visits" tableData={visits.visitsToday}/>
                </div>
                <div style={{ overflowY: "auto"}}>
                    <Table headers="Monthly Visits" tableData={visits.visitsMonth}/>
                </div>
                <div style={{gridColumn:"1 / span 2"}}>
                    <Table headers="In Building" tableData={currentEntry}/>
                </div>
            </div>
        </div>
        )
}


export default Home;