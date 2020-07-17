using Api.UseCases.UploadFile;
using Application.Boundaries.UploadFile;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Extensions
{
    public static class ApiServicesCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<IUploadFileOutputPorts, UploadFilePresenter>();
            services.AddScoped<UploadFilePresenter>();
            services.AddScoped(typeof(IUploadFileOutputPorts), sp => sp.GetRequiredService<UploadFilePresenter>());

            return services;
        }
    }
}
