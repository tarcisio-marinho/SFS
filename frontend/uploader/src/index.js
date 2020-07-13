import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
//import { sha256, sha224 } from "js-sha256";
import * as serviceWorker from "./serviceWorker";
import { App, fileToUp } from "./components/fristRoute/index.js";
import { Passwd, psw } from "./components/fristRoute/passwordComplet.js";
import "./components/fristRoute/style.css";
//import { encrypt, decrypt } from "./components/fristRoute/encryptionService.js";
//psw contem a senha
//

var ps = psw;
var ftp = File;
ftp = fileToUp;
function Updater() {
  if (fileToUp == null) {
    const element = (
      <div>
        <App />
        <Passwd />
      </div>
    );
    ReactDOM.render(element, document.getElementById("root"));
  } else {
    const element = (
      <div>
        <App />
        <div id="ps">{psw}</div>
        {fileToByte(fileToUp)}
      </div>
    );
    ReactDOM.render(element, document.getElementById("root"));
  }
}
setInterval(Updater, 400);

function fileToByte(result) {
  var reader = new FileReader();
  var fileByteArray = [];
  reader.readAsArrayBuffer(result[0]);

  reader.onloadend = function (evt) {
    if (evt.target.readyState === FileReader.DONE) {
      var arrayBuffer = evt.target.result,
        array = new Uint8Array(arrayBuffer);
      for (var i = 0; i < array.length; i++) {
        fileByteArray.push(array[i]);
      }
      //console.log(sha256(psw));
      //console.log(fileByteArray);
      //console.log(encrypt(fileByteArray, sha256(psw)));
    }
  };
}

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.register();
export { ps, ftp };
