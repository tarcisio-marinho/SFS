using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Errors
{
    public class InternalServerError
    {
        public Guid LogId { get; set; }
        public ICollection<string> Message { get; set; }
        public ICollection<string> StackTrace { get; set; }

        public InternalServerError()
        {
        }

        public InternalServerError(Exception exception, bool isDevelopment = false)
        {
            LogId = Guid.NewGuid();

            if (exception is AggregateException)
            {
                var agEx = exception as AggregateException;

                if (isDevelopment)
                {
                    Message = agEx.InnerExceptions.Select(e => e.Message).ToList();
                    StackTrace = agEx.InnerExceptions.Select(e => e.StackTrace).ToList();
                }
            }
            else if (exception != null && isDevelopment)
            {
                Message = new List<string>();
                StackTrace = new List<string>();

                BuildErrorPresentation(exception);
            }
        }

        private void BuildErrorPresentation(Exception ex)
        {
            if (ex.InnerException != null)
                BuildErrorPresentation(ex.InnerException);

            Message.Add(ex.Message);
            StackTrace.Add(ex.StackTrace);
        }
    }
}
