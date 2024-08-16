using Bet.Domain.Repositories.Team;
using Bet.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Infra.Repositories.Team;
internal class TeamRepository : ITeamRepository
{
    private readonly BettingDbContext _context;

    public TeamRepository(BettingDbContext context)
    {
        _context = context;
    }

    public async Task Add(Domain.Entities.Team team)
    {
        await _context.Teams.AddAsync(team);
    }

    public async Task<Domain.Entities.Team?> GetById(int id)
    {
        return await _context.Teams.FindAsync(id);
    }
}
