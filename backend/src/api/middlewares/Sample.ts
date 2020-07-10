import { Container } from 'typedi';

const Sample = async (req, res, next) => {
  const Logger = Container.get('logger');
    if (!true) {
        var error = " FATAL ERROR";
        Logger.error('Error: ', error);
        return res.sendStatus(401);
    }
    Logger.info("passed");
    return next();
};

export default Sample;
