using Bet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bet.Infra.Context;
public class BettingDbContext : DbContext
{
    public BettingDbContext(DbContextOptions<BettingDbContext> options) : base(options)
    {

    }

    //public DbSet<User> Users { get; set; } add user later
    public DbSet<Domain.Entities.Bet> Bets { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        Seed(modelBuilder);
    }

    private void Seed(ModelBuilder modelBuilder)
    {
        // Adicionar times
        modelBuilder.Entity<Team>().HasData(
            new Team { Id = 1, Name = "Team A" },
            new Team { Id = 2, Name = "Team B" },
            new Team { Id = 3, Name = "Team C" },
            new Team { Id = 4, Name = "Team D" }
        );

        // Adicionar partidas
        modelBuilder.Entity<Match>().HasData(
              new
              {
                  Id = 1,
                  TeamAId = 1,
                  TeamBId = 2,
                  AmountOnTeamA = 100.0m,
                  AmountOnTeamB = 150.0m
              },
              new
              {
                  Id = 2,
                  TeamAId = 3,
                  TeamBId = 4,
                  AmountOnTeamA = 200.0m,
                  AmountOnTeamB = 100.0m
              }
          );
    }
}

