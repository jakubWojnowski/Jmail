using Jmail.Application.Mappings;
using Jmail.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Jmail.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
        services.AddAutoMapper(typeof(JmailMappingProfile));
       
    }
}