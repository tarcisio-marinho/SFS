//imports
import React, { useState } from "react";
import Dropzone from "react-dropzone";
import { useHistory } from "react-router-dom";
import { Passwd } from "./passwordGenerationService";
import "./style.css";

//variables
//--rotation for password
var fileToUp,
  expireDate,
  isPage = false;
var showPasswd, intervalPassw;
showPasswd = Passwd();
intervalPassw = setInterval(updatePsw, 400);
function updatePsw() {
  showPasswd = Passwd();
}

//navegation
function navBar(history) {
  const goToDownload = () => {
    history.push("/download");
  };
  const goToHome = () => {
    history.push("/");
  };
  return (
    <div>
      <nav id="main-heade">
        <form class="form-inline">
          <button onClick={goToHome}>Goto Home</button>
          <button onClick={goToDownload}>Goto Download</button>
        </form>
      </nav>
    </div>
  );
}
//main element
function Home() {
  const history = useHistory();
  const handleChange = (event) => {
    clearInterval(intervalPassw);
    fileToUp = event[0];
  };
  const uploadFile = () => {
    isPage = true;
    const formData = new FormData();
    formData.append("file", fileToUp);
    fetch("http://localhost:3001/upload", {
      method: "POST",
      body: formData,
    })
      .then((response) => response.status) //expireDate=response.data
      .then((result) => isError(result))
      .catch((error) => console.log(error));
  };
  function isError(status) {
    if (status != 200) {
      history.push("/erro");
    } else {
      history.push("/sucess");
    }
  }

  return (
    <div id="fundo-externo">
      {navBar(history)}
      <header id="main-header">
        <h2>SFS</h2>
      </header>

      <div id="card">
        <div id="drop">
          {/*Drop files*/}
          <Dropzone onDrop={handleChange}>
            {({ getRootProps, getInputProps }) => (
              <section>
                <div {...getRootProps()}>
                  <input {...getInputProps()} />

                  <p>Click e escolha um arquivo ou arraste-o</p>
                </div>
              </section>
            )}
          </Dropzone>
        </div>

        <div id="ps">
          {/*password*/}
          {`${showPasswd}`}
        </div>

        <div id="but">
          {/*Button upload*/}
          <button onClick={uploadFile} id="button" type="submit">
            Submit
          </button>
        </div>
      </div>
    </div>
  );
}

//exports
export { Home, fileToUp, isPage };
