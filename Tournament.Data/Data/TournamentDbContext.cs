using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tournament.Core.Entities;

namespace Tournament.Data.Data
{
    public class TournamentDbContext : DbContext
    {
        public TournamentDbContext(DbContextOptions<TournamentDbContext> options)
        : base(options) { }

        public DbSet<Tournament.Core.Entities.Tournament> Tournaments { get; set; }
        public DbSet<Tournament.Core.Entities.Game> Games { get; set; }

    }
}