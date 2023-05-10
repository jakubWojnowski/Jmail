using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Jmail.Application.Mappings;
using Jmail.Application.MessageDto;
using Jmail.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Jmail.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
       
        services.AddScoped<IMessageService, MessageService>();
        services.AddValidatorsFromAssemblyContaining<SendMessageValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
        services.AddAutoMapper(typeof(JmailMappingProfile));
    }
}