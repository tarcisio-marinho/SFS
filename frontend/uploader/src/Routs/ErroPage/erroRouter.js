import React, { useState } from "react";
import "./style.css";
import { useHistory } from "react-router-dom";
import { isPage } from "../FristPage/homeRouter";

function ErrorRt() {
  const history = useHistory();
  const uploadFile = () => {
    history.push("/");
  };
  if (!isPage) {
    return null;
  } else {
    return (
      <div id="fundo-externo">
        <header id="main-header">
          <h2>Erro</h2>
        </header>
        <div id="main-header">
          <h4>não foi possivel realizar o upload</h4>
        </div>
        <div id="but">
          <button onClick={uploadFile} id="button" type="submit">
            Go Home
          </button>
        </div>
      </div>
    );
  }
}

export { ErrorRt };
