import { Router, Request, Response } from 'express';
import { DownloadDto } from '../dto/downloadDto';
const route = Router();

export default (app: Router) => {
  app.use('/download', route);

  route.post('/:id', (req: Request, res: Response) => {
	  // TODO pegar id da query string
	  // TODO: pegar senha do body da request
    return res.json(DownloadDto).status(200);
  });
};
