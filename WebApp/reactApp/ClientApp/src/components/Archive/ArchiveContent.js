import React, { useState,useEffect } from "react";
import { withRouter } from "react-router-dom";
import AxiosInstance from "./../../services/AuthService";
import Filter from "./Filter";
import Table from "./Table";

const ArchiveContent = (props) => {

    const [data, setData] = useState([]);

    useEffect(() => { setData(data); }, [data]);

    const searchArchiveHandler =  (e) => {
        e.preventDefault();
        const array = Array.prototype.slice.call(e.target.elements);

        AxiosInstance.axios.get("/archive", {
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
                Entered: array.find(el => el.name === "Entered").value === "on" ? true : false,
                Left: array.find(el => el.name === "Left").value === "on" ? true : false
            }
            }).then(data => setData(data.data)).catch(err => {
                localStorage.clear();
                props.history.push("/signin");
            });
        //if (result.status === "401") {
        //    props.history.push("/signin");
        //}
        //const newArray = result.data.map(el => ({ ...el }));
        //setData(newArray);
        
    }


    return (
        <div>
            <Filter searchArchiveHandler={searchArchiveHandler} />
            <Table tableData={data} />
        </div> 
    );
    
};
export default withRouter(ArchiveContent);