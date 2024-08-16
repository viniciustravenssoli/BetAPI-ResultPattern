namespace Bet.Domain.Entities;
public class Match
{
    public int Id { get; private set; }
    public int TeamAId { get; private set; }
    public int TeamBId { get; private set; }
    public decimal AmountOnTeamA { get; private set; }
    public decimal AmountOnTeamB { get; private set; }
    public ICollection<Bet> Bets { get; private set; } = new List<Bet>();

    private Match() { }

    // Construtor para criação de instâncias
    public Match(int teamAId, int teamBId, decimal amountOnTeamA, decimal amountOnTeamB)
    {
        TeamAId = teamAId;
        TeamBId = teamBId;
        AmountOnTeamA = amountOnTeamA;
        AmountOnTeamB = amountOnTeamB;
    }

    public void PlaceBet(int teamId, decimal amount)
    {
        if (teamId != TeamAId && teamId != TeamBId)
        {
            throw new InvalidOperationException("Invalid team selected.");
        }

        // Atualiza os montantes com base no time escolhido
        if (teamId == TeamAId)
        {
            AmountOnTeamA += amount;
        }
        else if (teamId == TeamBId)
        {
            AmountOnTeamB += amount;
        }

        // Outras regras de negócio ou atualizações podem ser feitas aqui
    }


}

