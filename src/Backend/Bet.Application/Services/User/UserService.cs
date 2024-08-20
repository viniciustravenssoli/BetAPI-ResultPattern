using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bet.Application.Commun;
using Bet.Application.DTOs;
using Bet.Application.DTOs.Responses;
using Bet.Application.Interfaces;
using Bet.Application.Services.Password;
using Bet.Application.Services.Token;
using Bet.Domain.Repositories.User;
using Bet.Infra.Uow;
using OneOf;

namespace Bet.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly PasswordEncryption _passwordHasher;
        private readonly TokenController _tokenController;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, PasswordEncryption passwordHasher, TokenController tokenController)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenController = tokenController;
        }

        public async Task<OneOf<ResponseLogin, AppError>> Login(LoginDTO request)
        {
            var encryptedPassword = _passwordHasher.Criptograph(request.Password);

            var user = await _userRepository.GetByEmailAndPassword(request.Email, encryptedPassword);

            if (user is null)
            {
                return new AppError("999-99", "Invalid User Email or Password");
            }

            return new ResponseLogin
            {
                Name = user.Username,
                Token = _tokenController.GenerateToken(user.Email)
            };

        }

        public async Task<OneOf<Domain.Entities.User, AppError>> RegisterUser(PlaceUserDTO request)
        {
            var hashedPassword = _passwordHasher.Criptograph(request.Password);

            var newUser = new Domain.Entities.User(request.UserName, request.Email, hashedPassword);

            try
            {
                await _userRepository.Add(newUser);
                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return new AppError("999-99", ex.Message);
            }

            return newUser;
        }
    }
}