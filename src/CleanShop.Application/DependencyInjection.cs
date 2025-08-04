using CleanShop.Application.Commands.Products.Create;
using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Application.Queries.Products;
using CleanShop.Application.Services;
using CleanShop.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CleanShop.Application;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IQueryHandler<GetProductsQuery, IEnumerable<Product>>, GetProductsQueryHandler>();
        services.AddScoped<IQueryHandler<GetProductByIdQuery, Product>, GetProductByIdQueryHandler>();
        services.AddScoped<ICommandHandler<CreateProductCommand, Product>, CreateProductCommandHandler>();

        services.AddScoped<IMediator, Mediator>();

        return services;
    }
}