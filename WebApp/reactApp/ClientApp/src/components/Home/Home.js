import React, { useState,useEffect } from "react";
import "./Home.css";
import AxiosInstance from "../../services/AuthService";
import axios from "axios";
import * as signalR from "@aspnet/signalr";
import Table from "../Archive/Table";
import Modal from "../Modal/Modal";

const Home = (props) => {

    const [visits, setVisits] = useState({
        visitsToday: [],
        visitsMonth: []        
    });
    const [modalData, setModalData] = useState(null);

    const [currentEntry, setCurrentEntry] = useState([]);
    useEffect(() => {
        const myHubConnection = new signalR.HubConnectionBuilder()
            .withUrl("/archivehub")
            .configureLogging(signalR.LogLevel.Information)
            .build();
        myHubConnection.serverTimeoutInMilliseconds = 100000;

        myHubConnection.start(() => console.log("WebSocket started")).catch(err => console.log(err));
         
        myHubConnection.on("RecieveMessage", (data) => {
            console.log(data);
            if (data.user) {
                setCurrentEntry(()=>[...currentEntry,data]);
            }
            
        });
        myHubConnection.on("UpdateMessage", (data) => {
            if (data.user) {
                setCurrentEntry(currentEntry.filter(element => element.userId !== data.userId));
            }
        });
        return () => myHubConnection.stop();
    }, [currentEntry]);
    
    useEffect(() => {
        if (localStorage["token"]) {
            AxiosInstance.get("/archive/currentEntries", { headers: { "authorization": "Bearer " + localStorage["token"] } })
            .then((data) => setCurrentEntry(data.data)).catch(err => props.history.push("/signin"));
        }
    //    return () => setVisits({ visitsMonth: [], visitsToday: [] });
    }, []);

    useEffect(() => {
        if (localStorage["token"]) {
            AxiosInstance.get("/archive/visits", { headers: { "authorization": "Bearer " + localStorage["token"] } })
                .then(data => setVisits(data.data)).catch(err => props.history.push("/signin"));
        }
    }, []);


    const showModalData = (info) => {
        setModalData(info);
    }

    const closeModalHandler = () => {
        setModalData(null);
    }


    return (
        <div style={{ height: "100%" }}>
            <Modal onClose={closeModalHandler} info={modalData} />
            <div className="myGrid">
                <div style={{ overflowY: "auto" }}>
                    <Table showModal={showModalData} headers="Today Visits" guests={true} tableData={visits.visitsToday} />
                </div>
                <div style={{ overflowY: "auto" }}>
                    <Table showModal={showModalData} headers="Monthly Visits" tableData={visits.visitsMonth} />
                </div>
                <div style={{ gridColumn: "1 / span 2" }}>
                    <Table showModal={showModalData} headers="In Building" tableData={currentEntry} />
                </div>
            </div>
        </div>
    );
}

export default Home;