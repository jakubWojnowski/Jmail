using Jmail.Application.Mappings;
using Jmail.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Jmail.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
       
        services.AddScoped<IMessageService, MessageService>();
        services.AddAutoMapper(typeof(JmailMappingProfile));
       
    }
}