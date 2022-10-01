import { useState } from "react";
import CreateToDoForm from "./Components/CreateToDo";
import Header from "./Components/Header";
import SelectDate from "./Components/SelectDate";
import ToDoItems from "./Components/ToDoItems";
import "./style.css"


function App(props) {

  const [createToDo, setCreateToDo] = useState(false);
  const [selectDate, setSelectDate] = useState(false);
  const today = new Date();
  const [date, setDate] = useState(document.location.pathname !== "/" ? document.location.pathname.substring(1) : `${today.getDate() >= 10 ? today.getDate() : "0" + today.getDate()}-${today.getMonth() + 1 >= 10 ? today.getMonth() + 1 : "0" + (today.getMonth() + 1).toString()}-${today.getFullYear()}`);
  const [toDos, setToDos] = useState([]);
  const splitDate = date.split("-");

  const openCreate = () => {
    setCreateToDo(true);
  }

  const closeCreate = () => {
    setCreateToDo(false);
  }

  const selectDateOpen = () => {
    setSelectDate(true);
  }

  const selectDateClose = () => {
    setSelectDate(false);
  }

  return (
    <>
      <Header openFuncCreate={openCreate} openFuncDate={selectDateOpen} date={`${splitDate[0]}-${splitDate[1]}-${splitDate[2]}`}/>
      <ToDoItems toDoList={toDos} setToDoList={setToDos} date={date}/>
      <CreateToDoForm toDoList={toDos} setToDoList={setToDos} createToDo={createToDo} closeFunc={closeCreate} date={date}/>
      <SelectDate closeCreate={setCreateToDo} toDoList={toDos} selectDate={selectDate} setToDoList={setToDos} closeFunc={selectDateClose} date={date} setDate={setDate}/>
    </>
  );
}

export default App;
