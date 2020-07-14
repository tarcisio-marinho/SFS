using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMessageProducers(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<ISendOrderForAnalysisOutputPorts, SendOrderForAnalysisProducer>();
            
            return services;
        }
    }
}
