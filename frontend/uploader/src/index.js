import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import * as serviceWorker from "./serviceWorker";
import { App, fileToUp } from "./components/fristRoute/index.js";
import { Passwd, psw } from "./components/fristRoute/passwordComplet.js";
import "./components/fristRoute/style.css";
//psw contem a senha
//
var ps=psw;
var ftp=File;
ftp =fileToUp;
function Updater() {
  if (fileToUp == null) {
    const element = (
      <div>
        <App />
        <Passwd />
        {console.log(fileToUp)}
      </div>
    );
    ReactDOM.render(element, document.getElementById("root"));
  }else{
    const element = (
      <div>
        <App />
        <div id="ps">{psw}</div>
        {console.log( fileToUp+'  :  '+psw)}
      </div>
    );
    ReactDOM.render(element, document.getElementById("root"));
  }
 
}
setInterval(Updater, 400);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.register();
export { ps, ftp };