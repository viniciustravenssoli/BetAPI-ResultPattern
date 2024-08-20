using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bet.Application.Commun;
using Bet.Application.DTOs;
using Bet.Application.DTOs.Responses;
using OneOf;

namespace Bet.Application.Interfaces
{
    public interface IUserService
    {
        Task<OneOf<Domain.Entities.User, AppError>> RegisterUser(PlaceUserDTO request);
        Task<OneOf<ResponseLogin, AppError>> Login(LoginDTO request);
    }
}