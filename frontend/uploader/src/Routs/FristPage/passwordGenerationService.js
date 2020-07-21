import React from "react";
import wordlist from "../utils/wordList.js";
import "./style.css";
import { fileToUp } from "./homeRouter.js";

var psw;

function Passwd ()  {
  function getWord() {
    let pos0 = String(getRndInteger(1, 5));
    let pos1 = String(getRndInteger(0, 6));
    let pos2 = String(getRndInteger(0, 10));
    let pos3 = String(getRndInteger(0, 10));

    var number = pos0 + pos1 + pos2 + pos3;
    return number;
  }

  function getRndInteger(min, max) {
    return Math.floor(Math.random() * (max - min)) + min;
  }

  function getFullPasswd() {
    var size = 6;
    var i = 0;
    var passwd = "";
    while (i < size) {
      var gen_number = getWord();
      var gen_word = wordlist[gen_number];

      if (gen_word) {
        passwd += gen_word + " ";
        i += 1;
      } else {
        continue;
      }
    }
    passwd = passwd.substring(0, passwd.length - 1);
    return passwd;
  }
  function chancevalue() {
    if (fileToUp == null) {
      psw = getFullPasswd();
    }
  }
  chancevalue();
  return psw;
};

export { Passwd, psw };
