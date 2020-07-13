import { Service, Inject } from 'typedi';
import { IStoredFile } from '../interfaces/IStoredFile';

@Service()
export default class DownloadService {
  constructor(
    @Inject('emailClient') private emailClient
  ) { }

    public async SendWelcomeEmail(email) {
    // TODO: implementar logica
    }
}
