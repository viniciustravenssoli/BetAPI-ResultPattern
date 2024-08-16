using Bet.Application.Commun;
using Bet.Application.DTOs;
using OneOf;

namespace Bet.Application.Interfaces;
public interface IBetService
{
    Task<OneOf<Domain.Entities.Bet, AppError>> PlaceBet(PlaceBetDTO dto);
}
