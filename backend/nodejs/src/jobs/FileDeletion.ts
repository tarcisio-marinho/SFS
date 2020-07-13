import { Container } from 'typedi';

export default class FileDeletion {
    public async handler(job, done): Promise<void> {
        const Logger = Container.get('logger');
        Logger.Info('Deleting files');
        await FileExlusionService.DeleteFiles(email);
        done();
    }
}
