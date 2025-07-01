using System.Threading.Tasks;
using Tournament.Core.Repositories;
using Tournament.Data.Data;
using GameRepo = Tournament.Data.Repositories.GameRepository;
using TournamentRepo = Tournament.Data.Repositories.TournamentRepository;

namespace Tournament.Data.Repositories;

public class UoW : IUoW
{
    private readonly TournamentDbContext _context;

    public ITournamentRepository TournamentRepository { get; }
    public IGameRepository GameRepository { get; }

    public UoW(TournamentDbContext context)
    {
        _context = context;
        TournamentRepository = new TournamentRepo(_context);
        GameRepository = new GameRepo(_context);
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}