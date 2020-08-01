import React from "react";
import { Switch, Route, useParams } from "react-router-dom";

var senha, time, fileId, fileToDownload;
function download() {
  const updatePassword = (e) => {
    senha = e.target.value;
  };
  const downloadFile = () => {
    const formData = new FormData();
    formData.append("string", senha);
    formData.append("string", fileId);

    /*fetch("http://localhost:3001/download", {
      method: "POST",
      body: formData,
    })
      .then(function (response) {
         response.json().then((data) => {
        fileToDownload=data.file
      });
        return response.status;
      }).catch((error) => console.log(error));*/
  };
  function fileExistes() {
    /*const formData = new FormData();
    formData.append("string", id);

    fetch("http://localhost:3001/exists", {
      method: "POST",
      body: formData,
    }).then(function (response) {
      response.json().then((data) => {
        time = data.time;
      });

      return response.status;
    });
    if (time == undefined) {
      return false;
    } else {
      return true;
    }*/
    return false;
  }
  function addingFile() {
    if (fileToDownload != null) {
      return (
        <div>
          <a
            href={window.URL.createObjectURL(fileToDownload)}
            download={fileToDownload.name}
          >
            asd
          </a>
        </div>
      );
    } else {
    }
  }
  if (fileId == null) {
    //captura o id
    return (
      <div>
        <Switch>
          <Route path="/:downlowad/:id" children={<GetId />} />
        </Switch>
      </div>
    );
  } else {
    if (fileExistes() === true) {
      return <div>File doesn't exist</div>;
    } else {
      return (
        <div id="fundo-externo">
          <header id="main-header">
            <h2>Download</h2>
          </header>

          <div id="card">
            {/*Drop files*/}

            <div id="drop">
              <div>
                <h3>arquivo: {fileId}</h3>
              </div>
              <p>insira a senha para baixar o arquivo</p>
              <input type="text" onInput={updatePassword} />

              <button onClick={downloadFile}>
                Download {addingFile()}
              </button>
            </div>
            <div>
              <p>tempo restante: {time}</p>
            </div>
          </div>
        </div>
      );
    }
  }
}

function GetId() {
  let { id } = useParams();

  return <div onLoadStart={(fileId = id)}></div>;
}
export { download };
