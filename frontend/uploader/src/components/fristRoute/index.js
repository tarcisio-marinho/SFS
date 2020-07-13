import React, { useCallback } from "react";
import { useDropzone } from "react-dropzone";
import { ftp } from "../../index.js";

import "./style.css";
var fileToUp = ftp;
const App = () => {
  const onDrop = useCallback((acceptedFiles) => {
    fileToUp = acceptedFiles;
  }, []);

  const {
    isDragActive,
    getRootProps,
    getInputProps,
    acceptedFiles,
  } = useDropzone({
    onDrop,
  });
  function chancevalue(acpf) {
    if (acpf != null) {
    } else {
      fileToUp = null;
    }
  }

  return (
    <div id="fundo-externo">
      <header id="main-header">
        <h2>SFS</h2>
      </header>

      <div id="card">
        {/*Drop files*/}

        <div id="image"></div>
        <div id="drop">
          {/*<img src="arquivo.png" width="60" height="40" />*/}
          <div id="textDrop" {...getRootProps()}>
            <input {...getInputProps()} />
            {!isDragActive && "Clique ou arraste um arquivo"}
            {isDragActive && "Já pode soltar ¯\\_(ツ)_/¯"}
          </div>
          <ul className="list-group mt-2">
            {acceptedFiles.map((acceptedFile) => (
              <div id="chanceFileName" key={acceptedFile.toString()}>
                {acceptedFile.name}
                {chancevalue(acceptedFile)}
              </div>
            ))}
          </ul>
        </div>

        {/*Button upload*/}
        <div id="upload">
          <button id="button">
            upload{/*mandar o acceptedFile para o backend*/}
          </button>
        </div>
      </div>
    </div>
  );
};

export { App, fileToUp };
