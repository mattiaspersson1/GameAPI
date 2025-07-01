using System.Collections.Generic;
using System.Threading.Tasks;
using GameEntity = Tournament.Core.Entities.Game;

namespace Tournament.Core.Repositories;

public interface IGameRepository
{
    Task<IEnumerable<GameEntity>> GetAllAsync();
    Task<GameEntity?> GetAsync(int id);
    Task<bool> AnyAsync(int id);
    void Add(GameEntity game);
    void Update(GameEntity game);
    void Remove(GameEntity game);
}