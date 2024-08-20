using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bet.Domain.Entities
{
    public class User
    {
        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set;}
        public ICollection<Bet> Bets { get; private set; } = new List<Bet>();

        // Método para adicionar uma aposta ao usuário
        public void AddBet(Bet bet)
        {
            if (bet.UserId != Id)
            {
                throw new InvalidOperationException("Bet does not belong to this user.");
            }

            Bets.Add(bet);
        }
    }
}