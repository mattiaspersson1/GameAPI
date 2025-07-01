using System;
using System.Collections.Generic;
using System.Linq;
using Tournament.Core.Entities;

namespace Tournament.Data.Data
{
    public static class TournamentDataSeeder
    {
        public static void Initialize(TournamentDbContext context)
        {
            if (context.Tournaments.Any()) return;

            var tournaments = new List<Tournament.Core.Entities.Tournament>
            {
                new Tournament.Core.Entities.Tournament
                {
                    Title = "Summer Cup",
                    StartDate = DateTime.Today.AddDays(-10),
                    Games = new List<Game>
                    {
                        new Game { Title = "Match 1", Time = DateTime.Today.AddDays(-9) },
                        new Game { Title = "Match 2", Time = DateTime.Today.AddDays(-8) }
                    }
                },
                new Tournament.Core.Entities.Tournament
                {
                    Title = "Winter Cup",
                    StartDate = DateTime.Today.AddDays(-20),
                    Games = new List<Game>
                    {
                        new Game { Title = "Match 3", Time = DateTime.Today.AddDays(-19) },
                        new Game { Title = "Match 4", Time = DateTime.Today.AddDays(-18) }
                    }
                }
            };

            context.Tournaments.AddRange(tournaments);
            context.SaveChanges();
        }
    }
}