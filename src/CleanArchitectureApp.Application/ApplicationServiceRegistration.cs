using System.Reflection;
using CleanArchitectureApp.Application.Helper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CleanArchitectureApp.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services here
            // For example:

            var assembly = Assembly.GetExecutingAssembly();

            // 1️⃣ Auto-register all FluentValidation validators in this assembly
            services.AddValidatorsFromAssembly(assembly);
            // └─ this finds every AbstractValidator<T> in 'assembly' and registers it as IValidator<T>

            // 2️⃣ Register the validation behavior in the MediatR pipeline
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // 2️⃣ Wire up MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            // 3️⃣ Removed the FluentValidation pipeline behavior for MediatR
            // If you need to integrate FluentValidation with MediatR, you may need to use a custom pipeline behavior.

            // 4️⃣ AutoMapper, etc.
            services.AddAutoMapper(assembly);
            return services;
        }
    }
}
