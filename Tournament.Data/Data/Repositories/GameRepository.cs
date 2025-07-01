using Microsoft.EntityFrameworkCore;
using Tournament.Core.Repositories;
using Tournament.Data.Data;
using GameEntity = Tournament.Core.Entities.Game;

namespace Tournament.Data.Repositories;

public class GameRepository : IGameRepository
{
    private readonly TournamentDbContext _context;

    public GameRepository(TournamentDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GameEntity>> GetAllAsync()
    {
        return await _context.Games.ToListAsync();
    }

    public async Task<GameEntity?> GetAsync(int id)
    {
        return await _context.Games.FindAsync(id);
    }

    public async Task<bool> AnyAsync(int id)
    {
        return await _context.Games.AnyAsync(g => g.Id == id);
    }

    public void Add(GameEntity game)
    {
        _context.Games.Add(game);
    }

    public void Update(GameEntity game)
    {
        _context.Games.Update(game);
    }

    public void Remove(GameEntity game)
    {
        _context.Games.Remove(game);
    }
}