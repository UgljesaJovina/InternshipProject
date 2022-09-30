import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

const root = ReactDOM.createRoot(document.getElementById('root'));

let today = new Date().toLocaleDateString().split("/");

root.render(
  <React.StrictMode>
    <Router>
      <Switch>
        <Route path="/" exact={true}>
          <App />
        </Route>
        <Route path="/([0-9]{2}-[0-9]{2}-[0-9]{4})" exact={false}>
          <App />
        </Route>
      </Switch>
    </Router>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();