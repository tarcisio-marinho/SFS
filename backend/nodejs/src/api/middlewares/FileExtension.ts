import config from '../../config';

// TODO: validate if middleware works
const getFileFromRequest = req => {
  if (!req.files){
    return null;
  }
  let uploadFile = req.files.uploadFile
  if(!uploadFile){
    return null;
  }
    
  return uploadFile;
};

const FileExtension = {
  getFile: getFileFromRequest, 
};

export default FileExtension;
