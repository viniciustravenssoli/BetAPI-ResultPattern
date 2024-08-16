namespace Bet.Domain.Entities;
public class Bet
{
    public Bet(int matchId, int userId, int teamId, decimal amount, decimal odd, DateTime betDate)
    {
        MatchId = matchId;
        UserId = userId;
        TeamId = teamId;
        Amount = amount;
        Odd = odd;
        BetDate = betDate;
    }

    public int Id { get; private set; }
    public int MatchId { get; private set; }
    public int UserId { get; private set; }
    public int TeamId { get; private set; }
    public decimal Amount { get; private set; }
    public decimal Odd { get; private set; }
    public DateTime BetDate { get; private set; }

}
