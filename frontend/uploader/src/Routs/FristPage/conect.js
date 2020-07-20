import React, { Component } from "react";
import Dropzone from 'react-dropzone'
import "./style.css";
import { App, fileToUp, a } from "./index.js.";
class Conect extends Component {
  /*
  constructor() {
    super();
    this.requestOptions = {
      method: "",
      body: "",
      redirect: "",
    };
  }

  handleSubmit = (event) => {
    
    fetch("http://localhost:3001/api", this.requestOptions)
      .then((response) => response.text())
      .then((result) => console.log(result))
      .catch((error) => console.log("erro", error));
  };
  onChangeHandler = (event) => {
    
    const data = new FormData();

    data.append("file", event.target.files[0]);

    this.requestOptions = {
      method: "POST",
      body: data,
      redirect: "follow",
    };
  };
*/
  render() {
    return (
      <div >
        {<App/>}

      </div>
    );
  }
}

export default Conect;
/*import React, { Component } from "react";
import  axios from 'axios';
import "./style.css";
import { App, fileToUp, a } from "./index.js";

state = {
    response: '',
    post: '',
    responseToPost: '',
  };
  
  componentDidMount() {
    this.callApi()
      .then(res => this.setState({ response: res.express }))
      .catch(err => console.log(err));
  }
  
  callApi = async () => {
    const response = await fetch('/api');
    const body = await response.json();
    if (response.status !== 200) throw Error(body.message);
    
    return body;
  };
  
  handleSubmit = async e => {
    e.preventDefault();
    const response = await fetch('/api', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: a,
    });
    const body = await response.text();
    console.log('123123 '+this.state.post+' tiagoi ');
    this.setState({ responseToPost: body });
  };

class Conect extends Component {
  
  constructor(props) {
    super(props);
      this.state = {
        selectedFile: null
      }
      this.requestOptions = {
        method: "",
        body: "",
        redirect: "",
      };
   
  }
 

  onClickHandler = () => {
    const data = new FormData() 
    
    data.append('file', this.state.selectedFile)
    
    this.requestOptions = {
      method: "POST",
      body: data,
      redirect: "follow",
    };
  fetch("http://localhost:3001/api", this.requestOptions)
      .then((response) => response.text())
      .then((result) => console.log(result))
      .catch((error) => console.log("erro", error));
}
  onChangeHandler = (event) => {
    
    this.state = {
      selectedFile: event.target.files[0]
    }
 
  };
  render() {
    return (
      <div className="App">
        
          <p>
            <strong>Post to Server:</strong>
          </p>
          <input type="file" name="file" onChange={this.onChangeHandler} />
          <button id="button" type="submit" onClick={this.onClickHandler}>
            Submit
          </button>
       
      </div>
    );
  }
}

export default Conect;
 */
