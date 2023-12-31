﻿using CrudTest.Application.Common.Interfaces.Persistence;
using CrudTest.Application.Common.Interfaces.Validations;
using CrudTest.Infrastructure.Persistence;
using CrudTest.Infrastructure.Persistence.Interceptors;
using CrudTest.Infrastructure.Persistence.Repositories;
using CrudTest.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrudTest.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddPersistence(configuration);

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder =>
                {
                    builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                }));

        services.AddScoped<ApplicationDbContextInitializer>();
        services.AddScoped<PublishDomainEventsInterceptor>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerValidation, CustomerValidation>();

        return services;
    }
}
