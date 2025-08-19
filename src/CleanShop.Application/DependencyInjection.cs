using CleanShop.Application.Commands.Basket;
using CleanShop.Application.Commands.Payment;
using CleanShop.Application.Commands.Products.Create;
using CleanShop.Application.Commons.Models;
using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Application.Queries.Basket;
using CleanShop.Application.Queries.Products;
using CleanShop.Application.Services;
using CleanShop.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CleanShop.Application;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IQueryHandler<GetProductsQuery, PagedList<Product>>, GetProductsQueryHandler>();
        services.AddScoped<IQueryHandler<GetProductByIdQuery, Product>, GetProductByIdQueryHandler>();
        services.AddScoped<IQueryHandler<GetProductFilterOptionsQuery, ProductFilterOptions>, GetProductFilterOptionsQueryHandler>();
        services.AddScoped<ICommandHandler<CreateProductCommand, Product>, CreateProductCommandHandler>();
        
        services.AddScoped<IQueryHandler<GetBasketQuery, Basket>, GetBasketQueryHandler>();
        services.AddScoped<IQueryHandler<GetItemFromBasketQuery, BasketItem>, GetItemFromBasketQueryHandler>();
        services.AddScoped<ICommandHandler<AddItemToBasketCommand, Basket>, AddItemToBasketCommandHandler>();
        services.AddScoped<ICommandHandler<RemoveItemFromBasketCommand, Basket>, RemoveItemFromBasketCommandHandler>();
        services.AddScoped<ICommandHandler<CreateBasketCommand, Basket>, CreateBasketCommandHandler>();
        
        services.AddScoped<ICommandHandler<CreateOrUpdatePaymentIntentCommand, PaymentResult>,CreateOrUpdatePaymentIntentCommandHandler>();

        services.AddScoped<IMediator, Mediator>();

        return services;
    }
}