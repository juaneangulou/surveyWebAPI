import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import Button from '@material-ui/core/Button';
import MyAPICalls from '../api_calls/my-api-calls';

const useStyles = makeStyles(theme => ({
    root: {
        width: '100%',
        marginTop: theme.spacing(3),
        overflowX: 'auto',
    },
    table: {
        minWidth: 650,
    },
}));


export default function QuestionTables(props) {
    const { rows } = props;
    const classes = useStyles();

   
    return (
        <Paper className={classes.root}>
            <Table className={classes.table}>
                <TableHead>
                    <TableRow>
                        <TableCell>Nombre</TableCell>

                    </TableRow>
                </TableHead>
                <TableBody>
                    {rows.map((row, index) => (
                        <TableRow key={row.id}>
                            <TableCell component="th" scope="row">
                                {row.questionName}
                            </TableCell>
                            <TableCell component="th" scope="row">
                                <Button variant="contained" color="primary" className={classes.button}>
                                    Votar Pregunta      </Button>
                                    <Button variant="contained" color="secondary" className={classes.button}  onClick={(e,row)=>{props.deleteQuestion(row)}}>
                                    Eliminar Pregunta      </Button>
                            </TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </Paper>
    );
}