import React, { Component } from "react";
import Header from "./header";
import FormQuestions from "../form-questions";

export default class Dashboard extends Component {
  render() {
    return (
      <div>
        <Header />
        <FormQuestions />
        <div />
      </div>
    );
  }
}
