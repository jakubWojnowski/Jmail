using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Jmail.Application.AdminPanel.Commands;
using Jmail.Application.ApplicationUser;
using Jmail.Application.Jmail.Commands.CreateEmail;
using Jmail.Application.Mappings;
using Jmail.Application.MessageDto;
using Jmail.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jmail.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserContext, UserContext>();
        services.AddMediatR(typeof(CreateEmailCommand));
        services.AddMediatR(typeof(DeleteUserCommand));
   

        services.AddValidatorsFromAssemblyContaining<CreateEmailCommandValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
        services.AddAutoMapper(typeof(JmailMappingProfile));
    }
}