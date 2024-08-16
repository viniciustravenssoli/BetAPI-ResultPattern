using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Application.DTOs;
public class PlaceBetDTO
{
    public int MatchId { get; set; }  // ID da partida na qual a aposta está sendo feita
    public int TeamId { get; set; }   // ID do time no qual o usuário está apostando
    public decimal Amount { get; set; }  // Valor que o usuário está apostando
}
