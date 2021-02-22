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

// connect to database

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

// get and update database

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

// file upload feature

var multer = require("multer");

var storage = multer.diskStorage({
  destination: function (req, file, cb) {
    cb(null, "public");
  },
  filename: function (req, file, cb) {
    cb(null, Date.now() + "-" + file.originalname);
  },
});

var upload = multer({ storage: storage }).single("file");

app.post("/api/upload/file", function (req, res) {
  console.log(res);

  upload(req, res, function (err) {
    if (err instanceof multer.MulterError) {
      return res.status(500).json(err);
    } else if (err) {
      return res.status(500).json(err);
    }
    return res.status(200).send(req.file);
  });
});

// listen for server port to receive connection

app.listen(SERVER_PORT, () =>
  console.log(`Server is running on port ${SERVER_PORT}.`)
);
