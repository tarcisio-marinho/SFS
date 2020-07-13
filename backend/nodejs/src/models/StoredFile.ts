import { IStoredFile } from '../interfaces/IStoredFile';
import mongoose from 'mongoose';

const StoredFile = new mongoose.Schema(
  {
    filePath: {
        type: String,
        unique: true,
        index: true,
    },

    fileName: {
        type: String,
        unique: true,
        index: true,
    },

    identifier: {
      type: String,
      unique: true,
      index: true,
    },

    password: {
      type: String,
      unique: true,
      index: true,
    },

    salt: String,

  },
  { timestamps: true },
);

export default mongoose.model<IStoredFile & mongoose.Document>('StoredFile', StoredFile);
