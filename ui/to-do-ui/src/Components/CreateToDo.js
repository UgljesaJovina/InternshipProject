import { useEffect } from "react";

export default function CreateToDoForm(props){

    const create = () => {
        const date = props.date.split("-");
        let toDoName = document.getElementById("toDoName");
        if (document.getElementById("toDoName").value.length <= 0) {
            let errorMsg = document.getElementById("errorMsg");
            toDoName.style.borderColor = "red";
            errorMsg.style.visibility = "visible";
        }
        else {
            const options = {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    name: toDoName.value,
                    dateCreated: (new Date(`${date[2]}-${date[1]}-${date[0]}T00:00:00+00:00`)).toISOString(),
                    done: false
                })
            }
            fetch ("https://localhost:7297/ToDoItems/MakeToDo", options)
            .then (res => res.json())
            .then (data => {
                if (!data.requestErrors){
                    let ls = [...props.toDoList];
                    ls.push(data);
                    props.setToDoList(ls);
                    toDoName.value = "";
                    props.closeFunc();
                }else {
                    alert(JSON.stringify(data.requestErrors))
                }
            })
        }
    }

    const returnColor = () => {
        let toDoName = document.getElementById("toDoName");
        let errorMsg = document.getElementById("errorMsg");
        toDoName.style.borderColor = "black";
        errorMsg.style.visibility = "hidden";
    }

    const closeOnEscape = e => {
        if ((e.charCode || e.keyCode) === 27){
            props.closeFunc();
            returnColor();
        }
        if ((e.charCode || e.keyCode) === 13){
            returnColor();
            create();
        }
    }

    useEffect(() => {
        document.body.addEventListener('keydown', closeOnEscape);
        return function cleanup() {
            document.body.removeEventListener('keydown', closeOnEscape);
        }
    })

    return (
        <div>
            <div className={`shade ${props.createToDo ? "show" : ""}`} onClick={() => {props.closeFunc(); returnColor()}}>
            </div>
            <div className={`modal ${props.createToDo ? "show" : ""}`}>
                <div className="modalTitle">
                    Create a new ToDo
                </div>
                <div className="modalContent">
                    <h3 id="errorMsg">This field cannot be empty!</h3>
                    <input type="text" id="toDoName" placeholder={"ToDo name..."} onChange={returnColor}/>
                </div>
                <button className="createButton" onClick={create}>Create</button>
                <button className="closeCreation" onClick={() => {props.closeFunc(); returnColor()}}>X</button>
            </div>
        </div>
    );
}