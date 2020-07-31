import React from "react";
import { Switch, Route, useParams } from "react-router-dom";

var senha, time, id;
function download() {
  const updatePassword = (e) => {
    senha = e.target.value;
  };
  const downloadFile = () => {
    const formData = new FormData();
    formData.append("string", senha);
    formData.append("string", id);

    /*fetch("http://localhost:3001/download", {
      method: "POST",
      body: formData,
    })
      .then(function (response) {
        return response.status;
      }) //expireDate=response.data
      .catch((error) => console.log(error));*/
  };
  function fileExistes() {
    time = "17/12/2020";
    /*const formData = new FormData();
    formData.append("string", id);

    fetch("http://localhost:3001/download/file/time", {
      method: "POST",
      body: formData,
    }).then(function (response) {
       response.json().then((data) => {//pegar o time no response
          
        });

      return response.status;
    }); //expireDate=response.data
    */
    return false;
  }
  if (fileExistes() === false) {
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
            <Switch>
              <Route path="/:downlowad/:id" children={<CatchId />} />
            </Switch>
            <p>insira a senha para baixar o arquivo</p>
            <input type="text" onInput={updatePassword} />

            <button onClick={downloadFile}>Download</button>
          </div>
          <div>
            <p>tempo restante: {time}</p>
          </div>
        </div>
      </div>
    );
  }
}

function CatchId() {
  id = useParams();

  return (
    <div>
      <h3>Identificação do arquivo: {id}</h3>
    </div>
  );
}
export { download };
