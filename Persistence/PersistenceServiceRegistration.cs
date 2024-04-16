using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("TestDb"));
        // services.AddDbContext<BaseDbContext>(options =>
        //      options.UseSqlServer(configuration.GetConnectionString("RentACar")));
        services.AddDbContext<BaseDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("WarehouseManagementSystem")));
          
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
        services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        
          
        // services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        // services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        // services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        // services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        // services.AddScoped<IUserRepository, UserRepository>();
        // services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        return services;
    }
}