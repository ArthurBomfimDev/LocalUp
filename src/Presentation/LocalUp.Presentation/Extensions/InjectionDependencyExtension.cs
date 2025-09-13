using FluentValidation;
using LocalUp.Application.Features.Users.Commands.Create;
using LocalUp.Application.Interfaces.Repository.Read;
using LocalUp.Application.Interfaces.Repository.Write;
using LocalUp.Application.Interfaces.UnitOfWork;

namespace LocalUp.Presentation.Extensions;

public static class InjectionDependencyExtension
{
    public static IServiceCollection ConfigureInjectionDependency(this IServiceCollection services)
    {
        //services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped<IBrandRepository, BrandRepository>();
        //services.AddScoped<ICategoryRepository, CategoryRepository>();
        //services.AddScoped<IProductRepository, ProductRepository>();
        //services.AddScoped<ICartRepository, CartRepository>();
        //services.AddScoped<IWishListRepository, WishListRepository>();

        //services.AddScoped<IUserReadRepository, UserReadRepository>();
        //services.AddScoped<IBrandReadRepository, BrandReadRepository>();
        //services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        //services.AddScoped<IProductReadRepository, ProductReadRepository>();
        //services.AddScoped<ICartReadRepository, CartReadRepository>();

        //services.AddScoped<IUnitOfWork, UnitOfWork>();

        //services.AddMediatR(typeof(CreateUserCommandHandler).Assembly);

        //services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

        return services;
    }
}