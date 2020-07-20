import React, { useState } from "react";

function download() {
  return (
    <div id="fundo-externo">
      <header id="main-header">
        <h2>Download</h2>
      </header>

      <div id="card">
        {/*Drop files*/}

        <div id="drop">
          <p>insira a senha para biaxar o arquivo</p>
        </div>
        <div>
          <p>tempo restante</p>
        </div>
        <div>
          <p>insira a senha para download</p>
          <button></button>
        </div>
      </div>
    </div>
  );
}

export { download };
