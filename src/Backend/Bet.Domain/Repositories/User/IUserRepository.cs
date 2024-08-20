using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bet.Domain.Repositories.User
{
    public interface IUserRepository
    {
        Task<bool> ExistUserWithEmail(string email);
        Task<Entities.User?> GetByEmailAndPassword(string email, string password);
        Task<Entities.User?> GetByEmail(string email);
        Task Add(Entities.User user);
    }
}