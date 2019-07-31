import React, { Component, useState, useEffect } from "react";
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
import MyAPICalls from '../api_calls/my-api-calls';
import moment from 'moment';
import uuid from 'uuid';
// import moment = require("moment");

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

export default  function FormQuestions() {
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

  useEffect(() => {
    const fetchData = async () => {
    const result = await MyAPICalls.get('/api/PulseSurveyMasters')
    setValues({...values,questions:result.data})
    };
    fetchData();
  }, []);

  const createQuestion= async()=>{

 
      const data={
        pulseSurveyMasterId: uuid(),
        questionName: values.questionName,
        dateCreated: moment().format('YYYY-MM-DD').toString(),
        isdone: false
      };
    
      const result = await MyAPICalls.post('/api/PulseSurveyMasters',data)
      const questions = await MyAPICalls.get('/api/PulseSurveyMasters')
      setValues({...values,questions:questions.data})
      
     //setValues({...values,questions:result.data})
      };
      const deleteQuestion= async(row)=>{
      console.log(row)
        // const result = await MyAPICalls.delete(`/api/PulseSurveyMasters/${id}`)
        // const questions = await MyAPICalls.get('/api/PulseSurveyMasters')
        // setValues({...values,questions:questions.data})
        
       //setValues({...values,questions:result.data})
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
          <Button variant="contained" color="primary" className={classes.button} onClick={()=>{createQuestion()}}>
            Crear Pregunta
      </Button>
        </Grid>
      </Grid>
      <TableQuestion rows={values.questions} deleteQuestion={deleteQuestion}/>
    </div>
  );
}
