using Microsoft.Extensions.DependencyInjection;
using SFS.Application.Services;
using SFS.Infrastructure.Data;
using SFS.Infrastructure.StoreFiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFS.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<IDataAccessor, DataAccessor>();
            services.AddScoped<IFileAccessor, FileAccessor>();

            return services;
        }
    }
}
