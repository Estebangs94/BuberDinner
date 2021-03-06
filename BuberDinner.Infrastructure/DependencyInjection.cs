using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastructure.Services;
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Infrastructure.Persistance;

namespace BuberDinner.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
