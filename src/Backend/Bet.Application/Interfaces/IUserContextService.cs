using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bet.Application.Interfaces
{
    public interface IUserContextService
    {
        Task<string?> GetUserToken();
    }
}