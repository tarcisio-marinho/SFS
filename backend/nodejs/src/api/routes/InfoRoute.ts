import { Router, Request, Response } from 'express';
import { InfoDto } from '../dto/infoDto';
import { celebrate, Joi } from 'celebrate';
const route = Router();

export default (app: Router) => {
  app.use('/info', route);

  route.get('/:id', 
  celebrate({
    query: {
      id: Joi.string().required(),
    },
  }),
  async (req: Request, res: Response) => {
    return res.json(InfoDto).status(200);
  });
};
