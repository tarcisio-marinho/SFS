import config from '../config';
import FileDeletion from '../jobs/FileDeletion';
import Agenda from 'agenda';

export default ({ agenda }: { agenda: Agenda }) => {
  agenda.define(
    'FileDeletion',
    { priority: 'high', concurrency: config.agenda.concurrency },
    // @TODO Could this be a static method? Would it be better?
    new FileDeletion().handler,
  );

  agenda.start();
};
