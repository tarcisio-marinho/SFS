import React, { useState } from "react";
import { psw } from "../FristPage/passwordGenerationService";
import { isPage, fileToUp } from "../FristPage/homeRouter";

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
              <p>
                Arquivo {`${fileToUp.name}`}
                <br />
                cifrado e salvo{" "}
              </p>
            </div>
            <div id="main-header ">
              <p>
                ulr
                <CopyToClipboard
                  text="url"
                  onCopy={() => this.setState({ copied: true })}
                >
                  <button>Copy Url</button>
                </CopyToClipboard>
              </p>
            </div>
            <div id="main-header ">
              <p>
                {psw}
                <CopyToClipboard
                  text={psw}
                  onCopy={() => this.setState({ copied: true })}
                >
                  <button>Copy Password</button>
                </CopyToClipboard>
              </p>
            </div>
            <div>
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
