import { useEffect } from "react";
import ToDo from "./ToDo";

export default function ToDoItems(props){

    const date = props.date.split("-");

    const handleDelete = (id) => {
        const allToDos = props.toDoList;
        const newList = props.toDoList.filter((el, i) => {
            if (el.id !== id){
                return true;
            }
            return false;
        })
        props.setToDoList(newList);
        fetch(`https://localhost:7297/ToDoItems/DeleteToDo/${id}`, {method: "DELETE"})
        .then(res => {
            if (Math.floor(res.status / 100) !== 2){
                props.setToDoList(allToDos);
            }
        });
    }

    useEffect(() => {
        fetch (`https://localhost:7297/ToDoItems/GetToDos?date=${date[1]}-${date[0]}-${date[2]}`)
        .then (res => res.json())
        .then (data => {
          props.setToDoList(data);
        });
      }, [props.date]);


    if (props.toDoList.length > 0){
        return (
            <div className="toDos">
                <ul>
                    {props.toDoList.map(el => <li key={el.id}><ToDo data={el} handleDelete={handleDelete}/></li>)}
                </ul>
            </div>
        );
    }else {
        return (
            <div className="noToDos">
                There is no ToDos for this day,<br /> yay!
            </div>
        )
    }
}