using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using LibroHub.Application.ApplicationUser;
using LibroHub.Application.LibroHub.Commands.CreateLibroHub;
using LibroHub.Application.Mappings;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LibroHub.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();

            services.AddMediatR(typeof(CreateLibroHubCommand));

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                //za każdym razem kiedy pobieramy lub konfig librohubdto automaper odczytuje usercontext
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new LibroHubMappingProfile(userContext));
            }).CreateMapper()
            );

            services.AddValidatorsFromAssemblyContaining<CreateLibroHubCommandValidator>()
                   .AddFluentValidationAutoValidation()
                   .AddFluentValidationClientsideAdapters();
        }
    }
}
