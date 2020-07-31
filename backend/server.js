const fileUpload = require("express-fileupload");
const cors = require("cors");
const morgan = require("morgan");
const _ = require("lodash");
var helmet = require("helmet");
const express = require("express");
const bodyParser = require("body-parser");
const app = express();

// TODO: Query database for inserted file

app.use(
  fileUpload({
    createParentPath: true,
  })
);
app.use(helmet());
app.disable("x-powered-by");
app.use(cors());
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));
app.use(morgan("dev"));

app.post("/upload", (req, res) => {
  if (!req.files) {
    return res.status(400).send({ msg: "file is not found" });
  }
  // accessing the file
  const myFile = req.files.file;
  //  mv() method places the file inside public directory
  return res.json({
    message: "File is uploaded",
    status: 200,
    date:"20/10/2000",
    filename: myFile.name
  });
});
app.post("/download", (req, res) => {
 return res.send(req.body)
});
/*
app.post('/api', async (req, res) => {
   
    try {
        if(!req.files) {
            res.send({
                status: false,
                message: 'No file uploaded'
            });
        } else {
            let avatar = req.files.avatar;
            avatar.mv('./api/' + avatar.name);

            //send response
            res.send({
                status: true,
                message: 'File is uploaded',
                data: {
                    name: avatar.name,
                    mimetype: avatar.mimetype,
                    size: avatar.size
                }
            });
        }
    } catch (err) {
        res.status(500).send(err);
    }
});
*/

const port = 3001;

app.listen(port, () => {});
