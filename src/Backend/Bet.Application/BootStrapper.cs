using Bet.Application.Interfaces;
using Bet.Application.Services.Bet;
using Bet.Application.Services.LoggedUser;
using Bet.Application.Services.Match;
using Bet.Application.Services.Password;
using Bet.Application.Services.Token;
using Bet.Application.Services.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Application;
public static class BootStrapper
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddServices(services);
        AddOptionalPassworKey(services, configuration);
        AddJwtToken(services, configuration);
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IBetService, BetService>();
        services.AddScoped<IMatchService, MatchService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ILoggedUser, LoggedUser>();
    }

    private static void AddOptionalPassworKey(IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetRequiredSection("Configurations:Key");

        services.AddScoped(option => new PasswordEncryption(section.Value));
    }

    private static void AddJwtToken(IServiceCollection services, IConfiguration configuration)
    {
        var sectionKey = configuration.GetRequiredSection("Configurations:TokenKey");
        var sectionTimeExpired = configuration.GetRequiredSection("Configurations:TokenTimeExpired");

        services.AddScoped(options => new TokenController(int.Parse(sectionTimeExpired.Value), sectionKey.Value));
    }
}
