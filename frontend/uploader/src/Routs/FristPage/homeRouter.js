//imports
import ReactDOM from "react-dom";
import React, { useState } from "react";
import Dropzone from "react-dropzone";
import { useHistory } from "react-router-dom";
import { Passwd } from "./passwordGenerationService";
import "./style.css";
import DownloadLink from "react-download-link";

//variables
//--rotation for password
var fileToUp,
  expireDate,
  isPage = false,
  url,
  isErro = false;
var showPasswd, intervalPassw;
showPasswd = Passwd();
intervalPassw = setInterval(updatePsw, 400);
function updatePsw() {
  showPasswd = Passwd();
}

//navegation

//main element
function Home() {
  const history = useHistory();
  const goToDownload = () => {
    history.push("/download");
  };

  const handleChange = (event) => {
    clearInterval(intervalPassw);
    fileToUp = event[0];
    console.log(fileToUp.name);
    console.log(fileToUp);
  };
  function test() {
    if (fileToUp != null) {
      return (
        <div>
          <a
            href={window.URL.createObjectURL(fileToUp)}
            download={fileToUp.name}
          >
            asd
          </a>
        </div>
      );
    } else {
    }
  }
  const uploadFile = () => {
    isPage = true;
    clearInterval(intervalPassw);

    const formData = new FormData();
    formData.append("file", fileToUp);

    fetch("http://localhost:3001/upload", {
      method: "POST",
      body: formData,
    })
      .then(function (response) {
        response.json().then((data) => {
          expireDate = data.date;
          url = "https://www.sfs.com/" + data.filename;
          console.log(expireDate);
          console.log(url);
        });

        return response.status;
      }) //expireDate=response.data
      .then((result) => isError(result))
      .catch((error) => console.log(error));
  };
  function isError(status) {
    if (status != 200) {
      isErro = true;
    } else {
      history.push("/sucess");
    }
  }
  if (isErro == false) {
    return (
      <div>
        <div id="fundo-externo">
          <header id="main-header">
            <h2>SFS</h2>
            <button id="btd" onClick={goToDownload}>
              Goto Download
            </button>
          </header>

          <div id="card">
            <div id="drop">
              {/*Drop files*/}
              <div id="textDrop">
                <Dropzone onDrop={handleChange}>
                  {({ getRootProps, getInputProps }) => (
                    <section>
                      <div {...getRootProps()}>
                        <input {...getInputProps()} />

                        {"Click e escolha um arquivo ou arraste-o"}
                      </div>
                    </section>
                  )}
                </Dropzone>
              </div>
            </div>

            <div id="ps">
              {/*password*/}
              {`${showPasswd}`}
            </div>

            <nav id="main-heade">
              <button onClick={uploadFile} id="bt" type="submit">
                Submit
              </button>
              {test()}
            </nav>
          </div>
        </div>
      </div>
    );
  } else {
    return (
      <div id="fundo-externo">
        <header id="main-header">
          <h2>Erro</h2>
        </header>
        <div id="main-header">
          <h4>não foi possivel realizar o upload</h4>
        </div>
        <div id="but"></div>
      </div>
    );
  }
}

//exports
export { Home, fileToUp, isPage, expireDate, url };
