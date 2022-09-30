import { useEffect, useState } from "react";

export default function Header(props){

    const date = props.date.split("-");

    const [quote, setQuote] = useState("");

    useEffect(() => {
        fetch ("./quotes.json")
        .then (res => res.json())
        .then (data => setQuote(data[Math.floor(Math.random() * data.length)]))
    }, [])

    return (
        <div className="header">
            <div className="container">
                <button className="addToDo" onClick={props.openFuncCreate}>+</button>
                <h1 className="quote">"{quote.text}"</h1>
                <h2 className="author">-{quote.author}</h2>
                <div className="dateDiv">
                    <input type="image" src="icon-calendar.svg" className="calendarImage" onClick={props.openFuncDate}/>
                    <h1 className="date">{`${date[0]}-${date[1]}-${date[2]}`}</h1>
                </div>
            </div>
        </div>
    );
}