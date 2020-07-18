import React, {useState, useEffect } from "react";
import "./Table.css";

const Table = ({ headers, tableData,showModal }) => {


  

    const dateOptions = {
        year: "numeric",
        month: "numeric",
        day: "numeric",
        hour: "numeric",
        minute:"numeric"
    };

    const convertImage = (picture) => {
        console.log(picture);
        let binary = "";
        let newBuffer = [].slice.call(new Uint8Array(picture));
        console.log(newBuffer);
        newBuffer.forEach(bin => binary += String.fromCharCode(bin));
        let result = "data:image/png;base64, " + window.btoa(binary);

        return result;
    }

 
    const data = (
        <table className="table table-striped myTable" style={{ overflowY: "auto" }}>
        <thead className="thead-light" style={{textAlign:"center"}}><tr><th colSpan="4">{headers}</th></tr>
        <tr>
            <th>Picture</th>
            <th>User</th>
            <th>Entered</th>
            <th>Left</th>
        </tr>
        </thead>
        <tbody style={{textAlign: "center", overflow: "auto" }}>
            {(tableData && tableData.length > 0) ? tableData.map((el, index) =>
                <tr key={index}>
                    <td><img onClick={showModal?()=>showModal(el):null} src={"data:image/png;base64, "+ el.picture} height="50px" width="50px" /></td>
                    <td>{el.user===null? <p>Visitor</p> : <p>{el.user.firstName + " " + el.user.lastName}</p>}</td>

                    {el.user === null ?
                        (<td colSpan="2">{new Date(el.enteredDate).toLocaleTimeString("de-DE", dateOptions)}</td>)
                        :
                        (<>
                            <td>{(el.enteredDate) ? new Date(el.enteredDate).toLocaleTimeString("de-DE", dateOptions) : "NO"}</td>
                            <td>{(el.leftDate) ? new Date(el.leftDate).toLocaleTimeString("de-DE", dateOptions) : "NO"}</td>
                        </>)
                     }
                </tr>
            ) : null}
        </tbody></table>);

    return (
       <React.Fragment>
            <div style={{height:"100%",overflowY:"scroll"}}>
                {data}
            </div>
        </React.Fragment>);


}
export default Table;