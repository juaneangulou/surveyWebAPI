import axios from 'axios';
import moment from 'moment';

const myClients = axios.create({
    baseURL: baseURL
    
});

myClients.interceptors.request.use(function (config) {
    config.headers = {
    'Content-Type': 'application/json',
    Accept: 'application/json',
    'Access-Control-Allow-Origin': '*',
    'X-Date': moment().format('YYYY-MM-DD HH:mm:ss')}
    return config;
}, function (err) {
    return err;
});

myClients.interceptors.response.use(response => {
    return response;
 }, error => {
   if (error.response.status === 401) {
    return error.response;
   }
   return error;
 });

export default myClients;