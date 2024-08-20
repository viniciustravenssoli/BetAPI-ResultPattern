using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bet.Domain.Repositories.User;
using Bet.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Bet.Infra.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly BettingDbContext _context;

        public UserRepository(BettingDbContext context)
        {
            _context = context;
        }

        public async Task Add(Domain.Entities.User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<bool> ExistUserWithEmail(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email.Equals(email));
        }

        public async Task<Domain.Entities.User?> GetByEmail(string email)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Equals(email));
        }

        public async Task<Domain.Entities.User?> GetByEmailAndPassword(string email, string password)
        {
            return await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Email.Equals(email) && c.Password.Equals(password));
        }

    }
}