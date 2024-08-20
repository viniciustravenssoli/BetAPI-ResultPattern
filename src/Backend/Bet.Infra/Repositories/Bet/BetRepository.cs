using Bet.Domain.Repositories.Bet;
using Bet.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Bet.Infra.Repositories.Bet;
internal class BetRepository : IBetRepository
{
    private readonly BettingDbContext _context;
    public BetRepository(BettingDbContext context)
    {
        _context = context;
    }

    public async Task Add(Domain.Entities.Bet bet)
    {
        await _context.Bets.AddAsync(bet);
    }

    public async Task<IEnumerable<Domain.Entities.Bet>> GetBets()
    {
        return await _context.Bets.ToListAsync();
    }

    public async Task<Domain.Entities.Bet?> GetById(int id)
    {
        return await _context.Bets.FindAsync(id);
    }
}
