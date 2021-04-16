// Modules needed for the webserver
const express = require('express');
const mysql = require('mysql');
const cors = require('cors');

const app = express();
const port = 5000;

// We use cors to prevent security issues
app.use(cors());
app.use(express.json());

// This is needed when we send forms to the api, so that the api knows how to process the body of the form
app.use(express.urlencoded({extended: true}));

function connectToDB()
{
    // Change the data to match your configuration.
    try{
        return mysql.createConnection({host:'127.0.0.1', user:'tc2005b', password:'HJFd@%2GuSv*@m', database:'api_test'});
        //return mysql.createConnection({host:'172.17.176.1', user:'hagen', password:'0412M4sqls3rv3r.', database:'api_test'});
    }
    catch(error){
        console.log(error);
    }
}

// This api recieves data in a form, and inserts it to the database.
app.post('/api/gamedata', (request, response)=>{

    try{
        console.log('Request data:', request.body);
        let connection = connectToDB();
        connection.connect();
        // Conveniently, the names of the fields match the names of the database columns, and we can insert the data as follows:
        const query = connection.query('insert into game_data set ?', request.body ,(error, results, fields)=>{

            // If there are no errors, we send a message back to unity that the data was inserted correctly.
            if(error)
                console.log(error);
            else
                response.json({'message': "Data inserted correctly."})
        });

        // Log everything in the server console.
        console.log(query.sql);
        connection.end();
    }
    catch(error)
    {
        console.log(error);
        connection.end();
        response.json(error);
    }
});

app.listen(port, ()=>
{
    console.log(`App listening at http://localhost:${port}`);
});
