using Jmail.Domain.Interfaces;
using Jmail.Infrastructure.Persistance;
using Jmail.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jmail.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<JmailDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("Jmail")));
        
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<JmailDbContext>();
    }
    
}