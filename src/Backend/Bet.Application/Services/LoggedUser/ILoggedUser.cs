using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bet.Domain.Entities;

namespace Bet.Application.Services.LoggedUser
{
    public interface ILoggedUser
    {
         Task<Domain.Entities.User> GetUser();
    }
}