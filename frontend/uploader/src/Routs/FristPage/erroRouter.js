import React, { useState } from "react";
import { Passwd } from "./passwordGenerationService";

function ErrorRt() {
  return (
    <div id="fundo-externo">
      <header id="main-header">
        <ul>
          <h1>Erro</h1>
          <h3>Não foi possivel realizar o upload</h3>
        </ul>
      </header>
    </div>
  );
}

export { ErrorRt };
