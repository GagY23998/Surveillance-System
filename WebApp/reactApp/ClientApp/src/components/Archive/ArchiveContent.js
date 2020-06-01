import React, { useState,useEffect } from "react";
import { withRouter } from "react-router-dom";
import AxiosInstance from "./../../services/AuthService";
import Filter from "./Filter";
import Table from "./Table";
import Modal from "../Modal/Modal";


const ArchiveContent = (props) => {

    const [data, setData] = useState([]);
    const [modalData, setModalData] = useState(null);

    //useEffect(() => { setData(data); }, [data]);

   
    const showModalData = (info) => {
        setModalData(info);
    }

    const closeModalHandler = () => {
        setModalData(null);
    }

    const searchArchiveHandler =  (e) => {
        e.preventDefault();
        const array = Array.prototype.slice.call(e.target.elements);
        console.log(array.find(el => el.name === "Entered"));
        console.log(array);
        AxiosInstance.get("/archive", {
            headers: {
                "content-type": "application/json; charset=utf-8",
                "accept": "application/json",
                "authorization": "Bearer " + localStorage["token"]
            },
            params: {
                FirstName: array.find(el => el.name === "FirstName").value,
                LastName: array.find(el => el.name === "LastName").value,
                FromDate: new Date(array.find(el => el.name === "FromDate").value).toJSON(),
                ToDate: new Date(array.find(el => el.name === "ToDate").value).toJSON(),
                Entered: array.find(el => el.name === "Entered").checked,
                Left: array.find(el => el.name === "Left").checked
            }
            }).then(data => setData(data.data)).catch(err => {
                localStorage.clear();
                props.history.push("/signin");
            });
    }   
    const roles = localStorage["roles"].split(",").findIndex(el => el === "Admin") === -1 ? null : "Admin";
    console.log(roles);
    return (
        <div style={{ height: "95%", position: "relative" }}>
            <Modal onClose={closeModalHandler} info={modalData} />
            {(roles === "Admin") ?
            (<React.Fragment><Filter searchArchiveHandler={searchArchiveHandler} />
                    <Table showModal={showModalData} tableData={data} /></React.Fragment>) : <p style={{fontWeight:"bold",position:"absolute",margin:"0",top:"50%",left:"50%",transform:"translate(-50%,-100%)"}}>You have no permission</p>
                }
        </div> 
    );
    
};
export default withRouter(ArchiveContent);