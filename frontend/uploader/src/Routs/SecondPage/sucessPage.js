import React, { useState } from "react";
import { psw } from "../FristPage/passwordGenerationService";
import { isPage } from "../FristPage/homeRouter";

import { CopyToClipboard } from "react-copy-to-clipboard";
var a;
class sucess extends React.Component {
  state = {
    value: "",
    copied: false,
  };

  render() {
    if (!isPage) {
      return null;
    } else {
      return (
        <div id="fundo-externo">
          <header id="main-header">
            <h2>Sucess</h2>
          </header>

          <div id="card">
            {/*Drop files*/}

            <div id="drop" text-align="center">
              <p>Arquivo cifrado e salvo</p>
            </div>
            <div id="main-header ">
              <p>ulr</p>
            </div>
            <div id="main-header ">
              <p>{psw}</p>
            </div>
            <div>
              <textarea
                value={psw}
                onChange={({ target: { value } }) =>
                  this.setState({ value, copied: false })
                }
              />

              <CopyToClipboard
                text={this.state.value}
                onCopy={() => this.setState({ copied: true })}
              >
                <span></span>
              </CopyToClipboard>

              <CopyToClipboard
                text={this.state.value}
                onCopy={() => this.setState({ copied: true })}
              >
                <button>Copiar</button>
              </CopyToClipboard>

              {this.state.copied ? (
                <span style={{ color: "green" }}>copiado.</span>
              ) : null}
            </div>
          </div>
        </div>
      );
    }
  }
}

export { sucess };
