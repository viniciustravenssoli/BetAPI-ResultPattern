using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bet.Application.DTOs.Responses
{
    public class ResponseLogin
    {
        public string Name { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}