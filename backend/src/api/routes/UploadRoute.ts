import { Router, Request, Response } from 'express';
import { UploadDto } from '../dto/uploadDto';
import { celebrate, Joi } from 'celebrate';
const route = Router();

export default (app: Router) => {
  app.use('/upload', route);

  route.post('/', 
  celebrate({
    body: Joi.object({
      password: Joi.string().required(),
    })    
  }),
  async (req: Request, res: Response) => {
      // TODO: pegar arquivo cifrado do req.files.FILENAME 
    return res.json(UploadDto).status(200);
  });
};
