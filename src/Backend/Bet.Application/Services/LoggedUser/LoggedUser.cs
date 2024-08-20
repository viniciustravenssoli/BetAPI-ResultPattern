using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bet.Application.Interfaces;
using Bet.Application.Services.Token;
using Bet.Domain.Entities;
using Bet.Domain.Repositories.User;


namespace Bet.Application.Services.LoggedUser
{
    public class LoggedUser : ILoggedUser
    {
        private readonly IUserContextService _contextService;
        private readonly TokenController _tokenController;
        private readonly IUserRepository _usuarioRepository;

        public LoggedUser(TokenController tokenController, IUserRepository usuarioRepository, IUserContextService contextService)
        {
            _tokenController = tokenController;
            _usuarioRepository = usuarioRepository;
            _contextService = contextService;
        }

        public async Task<Domain.Entities.User> GetUser()
        {
            var token = await _contextService.GetUserToken();
            var userEmail = _tokenController.GetEmail(token);

            var user = await _usuarioRepository.GetByEmail(userEmail);
            
            return user;
        }
    }
}