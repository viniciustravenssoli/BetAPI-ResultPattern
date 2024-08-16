using Bet.Domain;
using Bet.Domain.Repositories.Bet;
using Bet.Domain.Repositories.Match;
using Bet.Domain.Repositories.Team;
using Bet.Infra.Context;
using Bet.Infra.Repositories.Bet;
using Bet.Infra.Repositories.Match;
using Bet.Infra.Repositories.Team;
using Bet.Infra.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bet.Infra;
public static class BootStrapper
{
    public static void AddInfra(this IServiceCollection services, IConfiguration configurationManager)
    {
        AddRepositories(services);
        AddUnitOfWork(services);
        AddContext(services, configurationManager);
    }

    private static void AddContext(IServiceCollection services, IConfiguration configurationManager)
    {
        var connectionString = configurationManager.GetConnection2();

        services.AddDbContext<BettingDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
    }

    private static void AddUnitOfWork(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IBetRepository, BetRepository>();
        services.AddScoped<IMatchRepository, MatchRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
    }
}
