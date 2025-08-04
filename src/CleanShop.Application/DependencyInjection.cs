using CleanShop.Application.Commons;
using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Application.Products.Commands.Create;
using CleanShop.Application.Products.Queries;
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