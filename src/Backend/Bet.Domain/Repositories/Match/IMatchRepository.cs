using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Domain.Repositories.Match;
public interface IMatchRepository
{
    Task Add(Entities.Match match);
    Task<Entities.Match?> GetById(int id);
    Task<IEnumerable<Entities.Match>> GetMatches(); 
}
