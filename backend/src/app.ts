import 'reflect-metadata'; 
import config from './config';
import express from 'express';
import Logger from './modules/Logger';

async function startServer() {
  const app = express();
  await require('./modules').default({ expressApp: app });

  app.listen(config.port, err => {
    if (err) {
      Logger.error(err);
      process.exit(1);
      return;
    }
    Logger.info(`Server listening on port: ${config.port}`);
  });
}

startServer();
