using Bet.Domain.Repositories.Bet;
using Bet.Infra.Context;

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

    public Task<IEnumerable<Domain.Entities.Bet>> GetBets()
    {
        throw new NotImplementedException();
    }

    public async Task<Domain.Entities.Bet?> GetById(int id)
    {
        return await _context.Bets.FindAsync(id);
    }
}
