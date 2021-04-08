﻿using System;
using Chinook.Catalog.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Chinook.Catalog.Data.DependencyInjection
{
    public static class DataSetup
    {
        public static IServiceCollection ConfigureData(
            this IServiceCollection services,
            string connectionString,
            bool isDevelopment)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string may not be null, empty, or whitespace", nameof(connectionString));

            return services
                .AddDbContextPool<CatalogDbContext>(options =>
                {
                    options.UseNpgsql(connectionString);
                    options.EnableDetailedErrors(isDevelopment);
                    options.EnableSensitiveDataLogging(isDevelopment);
                })
                .AddScoped<ICatalogDbContext>(provider => provider.GetRequiredService<CatalogDbContext>());
        }
    }
}
