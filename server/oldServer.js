require("dotenv").config();
const express = require("express"),
  app = express(),
  cors = require("cors"),
  { SERVER_PORT, MYHOST, PASSWORD } = process.env,
  mysql = require("mysql");

let DATABASE = "";

let db_config = {};

app.use(express.json());
app.use(cors());

app.use(express.static(`${__dirname}/../build`));

var connection;

app.get("/api/database/:databaseName/:hostName", (req, res) => {
  console.log(
    "axios database request fired",
    req.params.databaseName,
    req.params.hostName
  );

  DATABASE = req.params.databaseName;
  console.log(DATABASE);
  db_config = {
    host: req.params.hostName,
    database: req.params.databaseName,
    user: req.params.databaseName,
    password: PASSWORD,
  };

  function handleDisconnect() {
    connection = mysql.createConnection(db_config);

    connection.connect(function (err) {
      if (err) {
        console.error("Error connecting: " + err.stack);
        return;
      }

      console.log("Connected as id " + connection.threadId);
    });

    connection.on("error", function (err) {
      console.log("db error", err);
      if (err.code === "PROTOCOL_CONNECTION_LOST") {
        handleDisconnect();
      } else {
        throw err;
      }
    });
  }
  handleDisconnect();

  res.status(200).send("database updated");
});

app.get("/api/info/:ftbNum", (req, res) => {
  console.log("axios request fired", req.params.ftbNum);

  connection.query(
    `SELECT * FROM tblftb WHERE ftbNum='${req.params.ftbNum}'`,
    function (error, results, fields) {
      if (error) throw error;

      results.forEach((result) => {
        console.log("result: ", result);

        res.status(200).send(result);
      });
    }
  );
});

app.get("/api/content/:ftbNum", (req, res) => {
  console.log("axios request fired", req.params.ftbNum);

  connection.query(
    `SELECT * FROM tblftb WHERE ftbNum='${req.params.ftbNum}'`,
    function (error, results, fields) {
      if (error) throw error;

      results.forEach((result) => {
        console.log("result.content: ", result);

        res.status(200).send(result.content);
      });
    }
  );
});

app.put("/api/update/content", (req, res) => {
  console.log(req);
  console.log("ftbNum: ", req.body.ftbNum);
  console.log("combinedHtml: ", req.body.combinedHtml);

  connection.query(
    `
    UPDATE tblftb 
    SET content='${req.body.combinedHtml}'
    WHERE ftbNum='${req.body.ftbNum}'
    `,
    function (error, results, fields) {
      if (error) throw error;

      res.status(200).send("Update Successful!");
    }
  );
});

app.delete("/api/", (req, res) => {
  console.log(req);
  res.status(200).send(response);
});

app.listen(SERVER_PORT, () =>
  console.log(`Server is running on port ${SERVER_PORT}.`)
);
