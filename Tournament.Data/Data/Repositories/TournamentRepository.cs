using Microsoft.EntityFrameworkCore;
using Tournament.Core.Repositories;
using Tournament.Data.Data;
using TournamentEntity = Tournament.Core.Entities.Tournament;

namespace Tournament.Data.Repositories;

public class TournamentRepository : ITournamentRepository
{
    private readonly TournamentDbContext _context;

    public TournamentRepository(TournamentDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TournamentEntity>> GetAllAsync()
    {
        return await _context.Tournaments
            .Include(t => t.Games)
            .ToListAsync();
    }

    public async Task<TournamentEntity?> GetAsync(int id)
    {
        return await _context.Tournaments
            .Include(t => t.Games)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<bool> AnyAsync(int id)
    {
        return await _context.Tournaments.AnyAsync(t => t.Id == id);
    }

    public void Add(TournamentEntity tournament)
    {
        _context.Tournaments.Add(tournament);
    }

    public void Update(TournamentEntity tournament)
    {
        _context.Tournaments.Update(tournament);
    }

    public void Remove(TournamentEntity tournament)
    {
        _context.Tournaments.Remove(tournament);
    }
}