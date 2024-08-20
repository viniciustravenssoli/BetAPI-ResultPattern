using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bet.Application.Interfaces;

namespace Bet.API
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string?> GetUserToken()
        {
            var authorization = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();

            return authorization["Bearer".Length..].Trim();
        }
    }
}