import React, { Component } from "react";
import { makeStyles } from "@material-ui/core/styles";
import Grid from "@material-ui/core/Grid";
import FormLabel from "@material-ui/core/FormLabel";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import RadioGroup from "@material-ui/core/RadioGroup";
import Radio from "@material-ui/core/Radio";
import Paper from "@material-ui/core/Paper";

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
  }
}));

export default class FormQuestions extends Component {
//   constructor() {
//     this.state = {values:{}};
//   }

  static propTypes = {
    prop: PropTypes
  };

  render() {
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
              label="Name"
              className={classes.textField}
              value={values.name}
              onChange={handleChange("name")}
              margin="normal"
            />
          </Grid>
        </Grid>
      </div>
    );
  }
}
