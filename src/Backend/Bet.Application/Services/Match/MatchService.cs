using Bet.Application.Interfaces;
using Bet.Domain.Repositories.Match;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Application.Services.Match;
internal class MatchService : IMatchService
{
    private readonly IMatchRepository _matchRepository;

    public MatchService(IMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }

    public async Task<Domain.Entities.Match?> GetById(int id)
    {
        return await _matchRepository.GetById(id);
    }
}
