var mysql = require('mysql');
const Joi = require('joi');
const express = require('express');
const app = express();
app.use(express.json());

app.get('/', (req, res) => {
    var con = mysql.createConnection({
        host: "localhost",
        user: "root",
        password: "cool1234"
      });
      
      con.connect(function(err) {
        if (err) throw err;
        console.log("Connected!");
      });
      res.send('Connected to the database!')
});

app.get('/api/customers', (req, res) => {
    var con = mysql.createConnection({
        host: "localhost",
        user: "root",
        password: "cool1234",
        database: "mydb"
      });
      
      con.connect(function(err) {
        if (err) throw err;
        con.query("SELECT * FROM customers", function (err, result, fields) {
          if (err) throw err;
          else{
            console.log(result);
            res.send(result);
          }
        });
      });
});

app.post('/api/customers',( req, res) => {
    var con = mysql.createConnection({
        host: "localhost",
        user: "root",
        password: "cool1234",
        database: "mydb"
      });
      
      con.connect(function(err) {
        if (err) throw err;
        var sql = "INSERT INTO customers (name, address) VALUES ('Michelle', 'Blue Village 1')";
        con.query(sql, function (err, result) {
          if (err) throw err;
          console.log("1 record inserted, ID: " + result.insertId);
        });
      });
});

app.put('/api/customers/:name', (req, res) => {
    var con = mysql.createConnection({
        host: "localhost",
        user: "root",
        password: "cool1234",
        database: "mydb"
      });
      
      con.connect(function(err) {
        if (err) throw err;
        var sql = "UPDATE customers SET name = 'Bill' WHERE name = '" + req.params.name + "'";
        con.query(sql, function (err, result) {
          if (err) throw err;
          console.log(result.affectedRows + " record(s) updated");
        });
      });

});

function validateCourse(course) {
    const schema = {
        name: Joi.string().min(3).required()
    };

    return Joi.validate(course, schema);
}

app.get('/api/customers/:name', (req, res) => {
    var con = mysql.createConnection({
        host: "localhost",
        user: "root",
        password: "cool1234",
        database: "mydb"
      });
      //con.connect(function(err){
       // if (err) throw err;
       con.connect(function(err) {
        if (err) throw err;
        con.query("SELECT * FROM customers WHERE name = '" + req.params.name + "'", function (err, result, fields) {
          if (err) throw err;
          else{
            console.log(result);
            res.send(result);
          }
        });
      });
});

app.delete('/api/customers/:name', (req, res) => {
    var con = mysql.createConnection({
        host: "localhost",
        user: "root",
        password: "cool1234",
        database: "mydb"
      });
      
      con.connect(function(err) {
        if (err) throw err;
        var sql = "DELETE FROM customers WHERE name = '"+ req.params.name +"'";
        con.query(sql, function (err, result) {
          if (err) throw err;
          console.log("Number of records deleted: " + result.affectedRows);
        });
      });

})

//PORT
const port = process.env.PORT || 3000;
app.listen(port, () => console.log(`Listening on port ${port}...`));