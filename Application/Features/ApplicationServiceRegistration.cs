using System;
using System.Reflection;
using Application.Services.PurchaseService;
using Application.Services.StockService;
using Application.Services.TransactionService;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Application.Rules;

namespace Application.Features;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly()); 
        
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));
        
        services.AddScoped<ITransactionService, TransactionManager>();
        services.AddScoped<IStockService, StockManager>();
        services.AddScoped<IPurchaseService, PurchaseManager>();

        return services;
    }
    
    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}