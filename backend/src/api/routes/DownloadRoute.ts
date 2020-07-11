import { Router, Request, Response } from 'express';
import { celebrate, Joi } from 'celebrate';
import { DownloadDto } from '../dto/downloadDto';
const route = Router();

export default (app: Router) => {
  app.use('/download', route);

  route.post('/:id', 
  celebrate({
    body: Joi.object({
      password: Joi.string().required(),
    }),
    query: {
      id: Joi.string().required(),
    },
  }),
  async (req: Request, res: Response) => {
    return res.json(DownloadDto).status(200);
  });
};
