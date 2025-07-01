using System.Collections.Generic;
using System.Threading.Tasks;
using TournamentEntity = Tournament.Core.Entities.Tournament;

namespace Tournament.Core.Repositories;

public interface ITournamentRepository
{
    Task<IEnumerable<TournamentEntity>> GetAllAsync();
    Task<TournamentEntity?> GetAsync(int id);
    Task<bool> AnyAsync(int id);
    void Add(TournamentEntity tournament);
    void Update(TournamentEntity tournament);
    void Remove(TournamentEntity tournament);
}