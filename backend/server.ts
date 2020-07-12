const express = require('express');
const fileUpload = require('express-fileupload');
const cors = require('cors');
const bodyParser = require('body-parser');
const morgan = require('morgan');
const _ = require('lodash');
var helmet = require('helmet')

const app = express();

// TODO: Query database for inserted file

app.use(fileUpload({
    createParentPath: true,
}));
app.use(helmet())
app.disable('x-powered-by')
app.use(cors());
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: true}));
app.use(morgan('dev'));

const port = process.env.PORT || 3000;

app.listen(port, ()=> {
    console.log('Application running ')
});

app.post('/Info', async (req, res) => {
    try {
        if(!req.files) {
            res.send({
                status: false,
                message: 'No file uploaded'
            });
        } else {
            let uploadedFile = req.files.file;
            uploadedFile.mv('C:\\Users\\tarcisio\\Desktop\\store/' + uploadedFile.name);

            //send response
            res.send({
                status: true,
                message: 'File is uploaded',
                data: {
                    name: uploadedFile.name,
                    mimetype: uploadedFile.mimetype,
                    size: uploadedFile.size
                }
            });
        }
    } catch (err) {
        res.status(500).send(err);
    }
});

app.post('/Download', async (req, res) => {
    try {
        if(!req.files) {
            res.send({
                status: false,
                message: 'No file uploaded'
            });
        } else {
            let uploadedFile = req.files.file;
            uploadedFile.mv('C:\\Users\\tarcisio\\Desktop\\store/' + uploadedFile.name);

            //send response
            res.send({
                status: true,
                message: 'File is uploaded',
                data: {
                    name: uploadedFile.name,
                    mimetype: uploadedFile.mimetype,
                    size: uploadedFile.size
                }
            });
        }
    } catch (err) {
        res.status(500).send(err);
    }
});

app.post('/Upload', async (req, res) => {
    try {
        if(!req.files) {
            res.send({
                status: false,
                message: 'No file uploaded'
            });
        } else {
            let uploadedFile = req.files.file;
            uploadedFile.mv('C:\\Users\\tarcisio\\Desktop\\store/' + uploadedFile.name);

            //send response
            res.send({
                status: true,
                message: 'File is uploaded',
                data: {
                    name: uploadedFile.name,
                    mimetype: uploadedFile.mimetype,
                    size: uploadedFile.size
                }
            });
        }
    } catch (err) {
        res.status(500).send(err);
    }
});


// INFO: GET /:ID -> retorna se o arquivo existe e quantos dias faltam para ele ser deletado

// UPLOAD: POST /file + senha -> faz o upload do arquivo para o servidor, o server vai retornar a url gerada para download do arquivo e o tempo restante para o arquivo ser deletado

// DOWNLOAD: POST /:ID + SENHA -> tenta baixar o arquivo, envia a senha, o servidor checa a senha, caso correta, retorna o arquivo, caso não, erro
