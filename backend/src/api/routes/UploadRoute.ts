import { Router, Request, Response } from 'express';
import { UploadDto } from '../dto/uploadDto';
import { celebrate, Joi } from 'celebrate';
import middlewares from '../middlewares';
const route = Router();

// TODO: validate middleware
export default (app: Router) => {
  app.use('/upload', route);

  route.post('/', 
  celebrate({
    body: Joi.object({
      password: Joi.string().required(),
    })    
  }),
  middlewares.FileExtension,
  async (req: Request, res: Response) => {
    return res.json(UploadDto).status(200);
  });
};
