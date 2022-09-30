import { useEffect, useState } from "react";

export default function ToDo(props){

    const [click, setClick] = useState(false);
    const [checked, setChecked] = useState(props.data.done);

    useEffect(() => {
        const btn = document.getElementById(props.data.id);

        const options = {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: props.data.name,
                done: btn.checked
            })
        }
        fetch (`https://localhost:7297/ToDoItems/ChangeToDo/${props.data.id}`, options)
        .then (res => res.json())
        .then (data => {
            btn.checked = data.done;
        })
    }, [click])


    function check() {
        const btn = document.getElementById(props.data.id);
        btn.checked = !btn.checked;
        setChecked(btn.checked);
        setClick(!click);
    } 


    return(
        <div className="toDoItem">
            <ul onClick={() => check()} className={`toDoItemContent ${checked ? "finished" : ""}`}>
                <li className="title">
                    {props.data.name}
                </li>
                <div className="flex">
                    <li className="buttonContainer">
                        <input type="checkbox" className="check" defaultChecked={props.data.done} id={props.data.id} onClick={(e) => check()}/>
                    </li>
                    <li className="imageContainer">
                        <input type="image" className="delete" src="trashcan.png" alt="kantica" onClick={() => props.handleDelete(props.data.id)}/>
                    </li>
                </div>
            </ul>
        </div>
    );
}
