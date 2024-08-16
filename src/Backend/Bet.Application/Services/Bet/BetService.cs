using Bet.Application.Commun;
using Bet.Application.DTOs;
using Bet.Application.Interfaces;
using Bet.Domain.Repositories.Bet;
using Bet.Infra.Uow;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Application.Services.Bet;
internal class BetService : IBetService
{
    private readonly IMatchService _matchService;
    private readonly IBetRepository _betRepository;
    private readonly IUnitOfWork _unitOfWork;


    public BetService(IMatchService matchService, IBetRepository betRepository, IUnitOfWork unitOfWork)
    {
        _matchService = matchService;
        _betRepository = betRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<OneOf<Domain.Entities.Bet, AppError>> PlaceBet(PlaceBetDTO dto)
    {
        var match = await _matchService.GetById(dto.MatchId);

        if (match == null)
        {
            return new AppError("MatchNotFound", "The specified match could not be found.");
        }

        match.PlaceBet(dto.TeamId, dto.Amount);


        var odd = CalculateOdds(match.AmountOnTeamA, match.AmountOnTeamB, dto.TeamId, match.TeamAId, match.TeamBId);

        var bet = new Domain.Entities.Bet(dto.MatchId, 1, dto.TeamId, dto.Amount, odd, DateTime.UtcNow);

        await _betRepository.Add(bet);
        await _unitOfWork.Commit();

        return bet;
    }

    private decimal CalculateOdds(decimal amountOnTeamA, decimal amountOnTeamB, int selectedTeamId, int teamAId, int teamBId)
    {
        // Lógica para calcular as odds
        decimal totalAmount = amountOnTeamA + amountOnTeamB;

        if (selectedTeamId == teamAId)
        {
            return totalAmount / amountOnTeamA;
        }
        else if (selectedTeamId == teamBId)
        {
            return totalAmount / amountOnTeamB;
        }

        return 0; // Retorna 0 como valor padrão
    }
}
