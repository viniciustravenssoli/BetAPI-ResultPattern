using Bet.Domain.Repositories.Match;
using Bet.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Bet.Infra.Repositories.Match;
internal class MatchRepository : IMatchRepository
{
    private readonly BettingDbContext _context;

    public MatchRepository(BettingDbContext context)
    {
        _context = context;
    }

    public async Task Add(Domain.Entities.Match match)
    {
        await _context.Matches.AddAsync(match);
    }

    public async Task<Domain.Entities.Match?> GetById(int id)
    {
        return await _context.Matches.FindAsync(id);
    }

    public async Task<IEnumerable<Domain.Entities.Match>> GetMatches()
    {
        return await _context.Matches.ToListAsync();
    }
}
