import { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";

export default function SelectDate(props){

    const [localDate, setLocalDate] = useState(props.date.split('-'));

    const history = useHistory();

    const setDate = () => {
        const dateObj = document.getElementById("dateSelector");
        if (dateObj.value === ""){
            let errorMsg = document.getElementById("errorMsgDate");
            dateObj.style.borderColor = "red";
            errorMsg.style.visibility = "visible";
        }else{
            history.push(`/${localDate[2]}-${localDate[1]}-${localDate[0]}`);
            props.setDate(`${localDate[2]}-${localDate[1]}-${localDate[0]}`);
            props.closeFunc();
        }
    }

    const closeOnEscape = e => {
        if ((e.charCode || e.keyCode) === 27){
            props.closeFunc();
            returnColor();
        }
        if ((e.charCode || e.keyCode) === 13){
            returnColor();
            setDate();
        }
    }

    function returnColor(){
        let errorMsg = document.getElementById("errorMsgDate");
        document.getElementById("dateSelector").style.borderColor = "black";
        errorMsg.style.visibility = "hidden";
    }

    useEffect(() => {
        document.body.addEventListener('keydown', closeOnEscape);
        return function cleanup() {
            document.body.removeEventListener('keydown', closeOnEscape);
        }
    })

    return (
        <div>
            <div className={`shade ${props.selectDate ? "show" : ""}`} onClick={() => {props.closeFunc(); returnColor()}}>
            </div>
            <div className={`dateModal ${props.selectDate ? "show" : ""}`}>
                <div className="dateModalTitle">
                    Select Date
                </div>
                <div className="dateModalContent">
                    <h3 id="errorMsgDate">This field cannot be empty!</h3>
                    <input type="date" id="dateSelector" onChange={(e) => {
                        setLocalDate(e.target.value.split("-"));
                        returnColor();
                    }}/>
                </div>
                <button className="selectButton" onClick={setDate}>Select</button>
                <button className="closeCreation" onClick={props.closeFunc}>X</button>
            </div>
        </div>
    );
}