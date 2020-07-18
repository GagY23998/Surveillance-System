import React, { useState,useEffect, useRef } from "react";
import "./Home.css";
import AxiosInstance from "../../services/AuthService";
import { HubConnectionBuilder,LogLevel } from "@aspnet/signalr";
import Table from "../Archive/Table";
import Modal from "../Modal/Modal";
import Spinner from "../Helper/Spinner";
const Home = (props) => {

    //const [visits, setVisits] = useState({
    //    visitsToday: [],
    //    visitsMonth: []        
    //});

    const [visitsToday, setVisitsToday] = useState([]);
    const [visitsMonth, setVisitsMonth] = useState([]);

    //useEffect(() => {
    //    localStorage.setItem("history", history.location.pathname);
    //}, []);
    const [modalData, setModalData] = useState(null);
    const isMounted = useRef(false);
    const monthMounted = useRef(false);
    const entrieMounted = useRef(false);
    const entries = useRef([]);
    const [hubConnection, setHubConnection] = useState(null);
    const [currentEntry, setCurrentEntry] = useState([]);
    

    useEffect(() => {
        if (!isMounted.current) {
            console.log("Fetching data starting");
            AxiosInstance.get("/archive/visitstoday", { headers: { "authorization": "Bearer " + localStorage["token"] } })
                .then(data => {
                    console.log(data.data);
                    setVisitsToday([...data.data]);
                }).catch(err => {
                    localStorage.setItem("history", props.history.location.pathname);
                    props.history.push("/signin");
                });
        }
        return () => { isMounted.current = true; };
    },[]);

    useEffect(() => {
        if (!monthMounted.current) {
        AxiosInstance.get("/archive/visitsMonth", { headers: { "authorization": "Bearer " + localStorage["token"] } })
            .then(data => {
                console.log(data.data);
                setVisitsMonth([...data.data]);
            }).catch(err => {
                localStorage.setItem("history", props.history.location.pathname);
                props.history.push("/signin");
            });
        }
        return () => { monthMounted.current = true; };
    },[]);

    useEffect(() => {

            const myHubConnection = new HubConnectionBuilder()
                .withUrl("/archivehub")
                .configureLogging(LogLevel.Information)
                .build();
            myHubConnection.serverTimeoutInMilliseconds = 100000;

            myHubConnection.start(() => console.log("WebSocket started")).catch(err => console.log(err));

                console.log("Adding events to hub");
                myHubConnection.on("RecieveMessage", (data) => {
                    console.log(data);
                    if (data.user) {
                        entries.current = [...entries.current, data];
                        setCurrentEntry([...entries.current]);
                    }

                });
                myHubConnection.on("UpdateMessage", (data) => {
                    if (data.user) {
                        entries.current = [...entries.current.filter(element => element.userId !== data.userId)];
                        setCurrentEntry(entries.current);
                    }
                });
        return () => setHubConnection(myHubConnection);
    }, []);

    useEffect(() => {
        if (!entrieMounted.current) {
            AxiosInstance.get("/archive/currentEntries", { headers: { "authorization": "Bearer " + localStorage["token"] } })
                .then((data) => {
                    entries.current = [...data.data];
                    setCurrentEntry([...entries.current]);
                }).catch(err => {
                    if (props.history.location.pathname !== "/signin") {
                        localStorage.setItem("history", props.history.location.pathname);
                        props.history.push("/signin");
                    }
                });
        }
        return () => { entrieMounted.current = true; };
    //    return () => setVisits({ visitsMonth: [], visitsToday: [] });
    },[]);


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
                    {visitsToday ?<Table showModal={showModalData} headers="Today Visits" guests={true} tableData={visitsToday} />:<Spinner/>}
                </div>
                <div style={{ overflowY: "auto" }}>
                    {visitsMonth ? <Table showModal={showModalData} headers="Monthly Visits" tableData={visitsMonth} /> : <Spinner />}
                </div>
                <div style={{ gridColumn: "1 / span 2" }}>
                    <Table showModal={showModalData} headers="In Building" tableData={currentEntry} />
                </div>
            </div>
        </div>
    );
}

export default Home;