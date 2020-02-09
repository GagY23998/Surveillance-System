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
        console.log("From Table");
        console.log(tableData);
        setDataArray(tableData);
    }, [tableData]);


    return (
        <React.Fragment>
            <table className="table table-bordered myTable">
                <thead>
                    {(headers) ? <tr><th colSpan="4">{headers}</th></tr>:null}
                    <tr>
                        <th>User</th>
                        <th>Date</th>
                        <th>Entered</th>
                        <th>Left</th>
                    </tr>
                </thead>
                <tbody> 
                    {(dataArray && dataArray.length > 0) ? dataArray.map((el, index) => 
                        <tr key={index}>
                            <td>{el.user.firstName + ' ' + el.user.lastName}</td>
                            <td>{new Date(el.timeStamp).toLocaleDateString("de-DE",dateOptions)}</td>
                            <td>{(el.Entered && el.Entered === true) ? "YES" : "NO"}</td>
                            <td>{(el.Left && el.Left === true) ? "YES" : "NO"}</td>
                        </tr>
                    ):null}
                </tbody>
            </table>
        </React.Fragment>);


}
export default Table;