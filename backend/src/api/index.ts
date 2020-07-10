import { Router } from 'express';
import download from './routes/DownloadRoute';
import upload from './routes/UploadRoute';
import info from './routes/InfoRoute';

export default () => {
	const app = Router();
	download(app);
	upload(app);
	info(app);
	return app;
}