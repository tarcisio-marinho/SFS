//Imports
//react
import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import * as serviceWorker from "./serviceWorker";
//elements
import { fileToUp, Home, status } from "./Routs/FristPage/homeRouter.js";
import {
  psw,
  Passwd,
} from "./Routs/FristPage/passwordGenerationService.js";
import { sucess } from "./Routs/SecondPage/sucessPage.js";
//style
import "./index.css";
import "./Routs/FristPage/style.css";
//security
import { sha256 } from "js-sha256";
import { encrypt, decrypt } from "./Routs/utils/encryptionService";
import { ErrorRt } from "./Routs/FristPage/erroRouter";
import { download } from "./Routs/ThirdPage/downloadPage";

//Variables and updates

var int = setInterval(updateElements, 400);

//functions
//updateElements => while Passwd must to change
function updateElements() {
  if (fileToUp == null) {
    const element = (
      <BrowserRouter>
        <Switch>
          <Route path="/download" component={download} />
          <Route path="/erro" component={ErrorRt} />
          <Route path="/sucess" component={sucess} />

          <Route path="/" component={Home} />
        </Switch>
      </BrowserRouter>
    );
    ReactDOM.render(element, document.getElementById("root"));
  } else {
    const element = (
      <div>
        <BrowserRouter>
          <Switch>
            <Route path="/download" component={download} />
            <Route path="/erro" component={ErrorRt} />
            <Route path="/sucess" component={sucess} />

            <Route path="/" component={Home} />
            {clearInterval(int)}
          </Switch>
        </BrowserRouter>
      </div>
    );
    ReactDOM.render(element, document.getElementById("root"));
  }

  /*
    
  
    ReactDOM.render(element, document.getElementById("root"));
  }*/
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
