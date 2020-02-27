import React, { Component } from "react";
import logo from "./logo.svg";
import "./App.css";

/* eslint-disable import/no-webpack-loader-syntax */
// @ts-ignore
import Worker from "workerize-loader!./worker/main";

class App extends Component {
  componentDidMount() {
    const worker = Worker();

    worker.expensive(1000).then((count: number) => {
      console.log(`Ran ${count} loops`);
    });
  }
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <p>
            Edit <code>src/App.tsx</code> and save to reload.
          </p>
          <a
            className="App-link"
            href="https://reactjs.org"
            target="_blank"
            rel="noopener noreferrer"
          >
            Learn React
          </a>
        </header>
      </div>
    );
  }
}

export default App;
