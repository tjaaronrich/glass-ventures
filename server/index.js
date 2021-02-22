require("dotenv").config();
const express = require("express"),
  app = express(),
  cors = require("cors"),
  { SERVER_PORT } = process.env,
  mysql = require("mysql");

const ctrl = require("./controller");

app.use(express.json());
app.use(cors());

app.use(express.static(`${__dirname}/../Default.aspx`));

// get requests
app.get("/api/database/:databaseName/:hostName", ctrl.getConnection);
app.get("/api/info/:ftbNum", ctrl.getFtbInfo);
app.get("/api/content/:ftbNum", ctrl.getContent);

// post requests
app.post("/api/upload/file/:databaseName", ctrl.uploadImage);

// put requests
app.put("/api/update/content", ctrl.updateContent);


// listen for server port to receive connection
app.listen(SERVER_PORT, () =>
  console.log(`Server is running on port ${SERVER_PORT}.`)
);
