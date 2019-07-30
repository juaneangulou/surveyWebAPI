import React, { Component, useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
import Grid from "@material-ui/core/Grid";
import FormLabel from "@material-ui/core/FormLabel";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import RadioGroup from "@material-ui/core/RadioGroup";
import Radio from "@material-ui/core/Radio";
import Paper from "@material-ui/core/Paper";
import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";
import TableQuestion from '../components/table-questions';

const useStyles = makeStyles(theme => ({
  root: {
    flexGrow: 1
  },
  paper: {
    height: 140,
    width: 100
  },
  control: {
    padding: theme.spacing(2)
  },
  button: {
    margin: theme.spacing(1),
  },
}));

export default async function FormQuestions() {
  //   constructor() {
  //     this.state = {values:{}};
  //   }

  // static propTypes = {
  //   prop: PropTypes
  // };

  const [values, setValues] = React.useState({
    questionName: "",
    questions: []
  });
  const classes = useStyles();
  const handleChange = name => event => {
    setValues({ ...values, [name]: event.target.value });
  };



  return (
    <div>
      <Grid container className={classes.root} spacing={2}>
        <Grid item xs={6}>
          <TextField
            id="standard-name"
            label="Nombre"
            className={classes.textField}
            value={values.name}
            onChange={handleChange("questionName")}
            margin="normal"
          />
          <Button variant="contained" color="primary" className={classes.button}>
            Crear Pregunta
      </Button>
        </Grid>
      </Grid>
      <TableQuestion rows={values.questions} />
    </div>
  );
}
