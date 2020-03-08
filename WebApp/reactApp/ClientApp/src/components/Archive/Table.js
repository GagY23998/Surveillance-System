import React, {useState, useEffect } from "react";
import "./Table.css";

const Table = ({ headers, tableData }) => {

    const [dataArray, setDataArray] = useState(tableData);
    const dateOptions = {
        year: "numeric",
        month: "numeric",
        day: "numeric",
        hour: "numeric",
        minute:"numeric"
    };

    useEffect(() => {
        setDataArray(tableData);
    }, [tableData]);


    const convertImage = (picture) => {
        console.log(picture);
        let binary = "";
        let newBuffer = [].slice.call(new Uint8Array(picture));
        console.log(newBuffer);
        newBuffer.forEach(bin => binary += String.fromCharCode(bin));
        let result = "data:image/png;base64, " + window.btoa(binary);

        return result;
    }

    const showImage = (e) => {
        console.log(e.target);
        e.target.width = "200px";
        e.target.height = "200px";
    }
    const closeImage = (e) => {
        e.target.width = "20px";
        e.target.height = "20px";
    }

    return (
        <React.Fragment>
            <div>
                <table className="table table-striped myTable">
                    <thead className="thead-light">
                        {(headers) ? <tr><th colSpan="3">{headers}</th></tr>:null}
                        <tr>
                            <th>User</th>
                            <th>Entered</th>
                            <th>Left</th>
                        </tr>
                    </thead>
                    <tbody style={{ textAlign: "center" ,overflow:"scroll"}}> 
                        {(dataArray && dataArray.length > 0) ? dataArray.map((el, index) => 
                            <tr key={index}>
                                <td>{el.user.firstName + ' ' + el.user.lastName}</td>
                                <td>{(el.enteredDate) ? new Date(el.enteredDate).toLocaleTimeString("de-DE",dateOptions) : "NO"}</td>
                                <td>{(el.leftDate) ? new Date(el.leftDate).toLocaleTimeString("de-DE",dateOptions) : "NO"}</td>
                            </tr>
                        ):null}
                    </tbody>
                </table>
            </div>
        </React.Fragment>);


}
export default Table;