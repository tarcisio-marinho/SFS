import { Router, Request, Response } from 'express';
import { UploadDto } from '../dto/uploadDto';
const route = Router();

export default (app: Router) => {
  app.use('/upload', route);

  route.post('/', (req: Request, res: Response) => {
      // TODO: pegar senha do body
      // TODO: pegar arquivo cifrado do req.files.FILENAME 
    return res.json(UploadDto).status(200);
  });
};
