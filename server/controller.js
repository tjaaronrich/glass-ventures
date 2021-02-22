// connect to database vars
require("dotenv").config();
const { PASSWORD } = process.env,
  mysql = require("mysql");

let DATABASE = "";
let db_config = {};

var connection;

module.exports = {

  // get requests
  getConnection: (req, res) => {
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
  },
  
  getFtbInfo: (req, res) => {
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
  },

  getContent: (req, res) => {
    console.log("axios request fired", req.params.ftbNum);
  
    connection.query(
      `SELECT * FROM tblftb WHERE ftbNum='${req.params.ftbNum}'`,
      function (error, results, fields) {
        if (error) throw error;
  
        results.forEach((result) => {
          console.log("result.contnet: ", result.content);
  
          res.status(200).send(result.content);
        });
      }
    );
  },

  // new row creator

  // getContent: (req, res) => {
  //   console.log("axios request fired", req.params.ftbNum);
  
  //   connection.query(
  //     `SELECT * FROM tblrows WHERE ftbNum='${req.params.ftbNum} ORDER BY row_id ASC'`,
  //     function (error, results, fields) {
  //       if (error) throw error;
  
  //       results.forEach((result) => {
  //         console.log("result: ", result);
  
  //         res.status(200).send(result);
  //       });
  //     }
  //   );
  // },

  // post requests
  uploadImage: (req, res) => {

    // ***** this function will only work on the live site!!!! *****

    // create a new folder each time with the database name that we put in place of 'uploads' below to organize images.
    let databaseName = req.params.databaseName;
    console.log("uploadImage databaseName: ", databaseName);

    var multer = require("multer");
    let DateNow = "";

    var storage = multer.diskStorage({
      destination: function (req, file, cb) {
        cb(null, `public/${databaseName}`);
      },

      filename: function (req, file, cb) {
        cb(null, DateNow + "-" + file.originalname);
      },
    });

    var upload = multer({ storage: storage }).single("file");

    DateNow = Date.now();
  
    upload(req, res, function (err) {
      if (err instanceof multer.MulterError) {
        return res.status(500).json(err);
      } else if (err) {
        return res.status(500).json(err);
      }
      return res.status(200).send(req.file);
    });
  },

  // put requests
  updateContent: (req, res) => {
  // console.log(req);
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
},
  delete: (req, res) => {
    res.status(200).send([whatever]);
  },
};
