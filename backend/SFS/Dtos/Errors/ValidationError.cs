using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Errors
{
    public class ValidationError 
    {
        public string Message => $"One or more errors occurred while validating the input dto. Please check the property '{nameof(Errors)}' for details.";
        public object Input { get; set; }
        public IEnumerable<string> Errors { get; set; }


        public ValidationError(string exchangeName, object input, IEnumerable<string> errors)
        {
            Exchange = ExchangeConfiguration.Topic(exchangeName);
            Input = input;
            Errors = errors;
        }

        public ValidationError(string exchangeName, params string[] errors)
        {
            Errors = errors;
            Exchange = ExchangeConfiguration.Topic(exchangeName);
        }

        public ValidationError(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}
