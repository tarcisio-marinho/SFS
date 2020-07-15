//Imports
  //react
import React from "react";
import ReactDOM from "react-dom";
import * as serviceWorker from "./serviceWorker";
  //elements
import { App, fileToUp } from "./FirstRoute/components/index.js";
import { Passwd, psw } from "./FirstRoute/components/passwordGenerationService.js";
  //style
import "./index.css";
import "./FirstRoute/components/style.css";
  //security
import { sha256 } from "js-sha256";
import { encrypt, decrypt } from "./FirstRoute/utils/encryptionService";

//Variables and updates
var ps = psw;
var ftp = fileToUp;
var int = setInterval(updateElements, 400);

//functions
//updateElements => while Passwd must to change
function updateElements() {
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
        {clearInterval(int)}
        {fileToByte(fileToUp)}
      </div>
    );
    ReactDOM.render(element, document.getElementById("root"));
  }
}

//fileToByte => Transform file to byte array
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
      let shaPassword = sha256(psw);
      let encrypted = encrypt(fileByteArray, shaPassword);
      let decrypted = decrypt(encrypted, shaPassword);
      console.log(decrypted);
    }
  };
}

//System
serviceWorker.register();

//exports
export { ps, ftp };
