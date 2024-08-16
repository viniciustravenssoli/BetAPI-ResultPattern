namespace Bet.Domain.Repositories.Bet;
public interface IBetRepository
{
    Task Add(Entities.Bet bet);
    Task<Entities.Bet?> GetById(int id);
    Task<IEnumerable<Entities.Bet>> GetBets();
}
