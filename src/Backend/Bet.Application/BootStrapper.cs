using Bet.Application.Interfaces;
using Bet.Application.Services.Bet;
using Bet.Application.Services.Match;
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
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IBetService, BetService>();
        services.AddScoped<IMatchService, MatchService>();
    }
}
