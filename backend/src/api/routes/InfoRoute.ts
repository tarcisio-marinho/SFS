import { Router, Request, Response } from 'express';
import { InfoDto } from '../dto/infoDto';
const route = Router();

export default (app: Router) => {
  app.use('/info', route);

  route.get('/:id', (req: Request, res: Response) => {
      // TODO: retornar se existe e a quantidade de tempo restante 
    return res.json(InfoDto).status(200);
  });
};
