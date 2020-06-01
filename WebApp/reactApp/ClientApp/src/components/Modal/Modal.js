import React from "react";
import "./Modal.css";
const Modal = ({ info, onClose }) => {
    const dateOptions = {
        year: "numeric",
        month: "numeric",
        day: "numeric",
        hour: "numeric",
        minute: "numeric"
    };
    const data = info ? (<div className="Modaldiv">
        <div>
            <img src={"data:image/png;base64, " + info.picture} />
            <div>
                <div className="divInfo">
                <p className="left">Name:</p>
                    <p className="right"> {info.user ? info.user.firstName + " " + info.user.lastName : "Visitor"}</p>
                </div>
                {info.user?<><div className="divInfo">
                    <p className="left">Entered:</p>
                    <p className="right">{new Date(info.enteredDate).toLocaleTimeString("de-DE", dateOptions)}</p>
                </div>
                    <div className="divInfo">
                        <p className="left">Left:</p>
                        <p className="right">{new Date(info.leftDate).toLocaleTimeString("de-DE", dateOptions)}</p>
                    </div>
                    <div className="divInfo">
                        <button type="button" onClick={onClose}>Close</button>
                    </div> </>:<> <div className="divInfo">
                        <p className="left">Visited:</p>
                        <p className="right">{new Date(info.enteredDate).toLocaleTimeString("de-DE", dateOptions)}</p>
                        <button type="button" onClick={onClose}>Close</button>
                    </div></>} 
                    
            </div>
        </div>
    </div>) : null;

    return data;
}
export default Modal;