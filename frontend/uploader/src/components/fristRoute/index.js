import ReactDOM, { unstable_batchedUpdates } from "react-dom";
import React, { useCallback } from "react";
import { useDropzone } from "react-dropzone";
import { ps, ftp } from "../../index.js";

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
      <div>
        <header id="main-header">SFS</header>

        <div id="card">
          {/*Drop files*/}

          <div id="drop">
            {/*<img src="arquivo.png" width="60" height="40" />*/}
            <div id="textDrop" {...getRootProps()}>
              <input {...getInputProps()} />
              {!isDragActive && "Clique ou arraste um arquivo"}
              {isDragActive && "Já pode soltar ¯\\_(ツ)_/¯"}
            </div>
            <ul className="list-group mt-2">
              {acceptedFiles.map((acceptedFile) => (
                <li>

                  {acceptedFile.name}
                  {chancevalue(acceptedFile)}
                  
                
                </li>
              ))}
            </ul>
          </div>

          {/*Result senha*/}
          <div id="senha"></div>

          {/*Button upload*/}
          <div id="upload">
            <button for="input" id="button" class="button">
              upload{/*mandar o acceptedFile para o backend*/}
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export { App, fileToUp };
