using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Application.Interfaces;
public interface IMatchService
{
    Task<Domain.Entities.Match?> GetById(int id);
}
