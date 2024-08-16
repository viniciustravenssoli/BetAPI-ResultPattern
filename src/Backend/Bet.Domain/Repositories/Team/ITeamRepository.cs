using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Domain.Repositories.Team;
public interface ITeamRepository
{
    Task Add(Entities.Team team);
    Task<Entities.Team?> GetById(int id);
}
