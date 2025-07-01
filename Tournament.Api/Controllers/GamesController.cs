using Microsoft.AspNetCore.Mvc;
using Tournament.Core.Repositories;
using Tournament.Core.Dto;
using GameEntity = Tournament.Core.Entities.Game;
using AutoMapper;

namespace Tournament.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;

    public GamesController(IUoW uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets all games.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameDto>>> GetGames()
    {
        var games = await _uow.GameRepository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<GameDto>>(games));
    }

    /// <summary>
    /// Gets a specific game by its ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<GameDto>> GetGame(int id)
    {
        var game = await _uow.GameRepository.GetAsync(id);
        if (game == null)
            return NotFound();

        return Ok(_mapper.Map<GameDto>(game));
    }

    /// <summary>
    /// Updates an existing game.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGame(int id, GameEntity game)
    {
        if (id != game.Id)
            return BadRequest("ID mismatch");

        if (!await _uow.GameRepository.AnyAsync(id))
            return NotFound();

        var existing = await _uow.GameRepository.GetAsync(id);
        if (existing == null)
            return NotFound();

        existing.Title = game.Title;
        existing.Time = game.Time;
        existing.TournamentId = game.TournamentId;

        await _uow.CompleteAsync();

        var dto = _mapper.Map<GameDto>(existing);
        return Ok(dto);
    }

    /// <summary>
    /// Creates a new game.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<GameDto>> PostGame(GameEntity game)
    {
        _uow.GameRepository.Add(game);
        await _uow.CompleteAsync();

        var dto = _mapper.Map<GameDto>(game);
        return CreatedAtAction(nameof(GetGame), new { id = game.Id }, dto);
    }

    /// <summary>
    /// Deletes a game by ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(int id)
    {
        var game = await _uow.GameRepository.GetAsync(id);
        if (game == null)
            return NotFound();

        _uow.GameRepository.Remove(game);
        await _uow.CompleteAsync();

        return NoContent();
    }

    /// <summary>
    /// Partially updates game title.
    /// </summary>
    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchGameTitle(int id, [FromBody] string newTitle)
    {
        if (string.IsNullOrWhiteSpace(newTitle))
            return BadRequest("Title cannot be empty.");

        var game = await _uow.GameRepository.GetAsync(id);
        if (game == null)
            return NotFound();

        game.Title = newTitle;
        await _uow.CompleteAsync();

        return NoContent();
    }

    /// <summary>
    /// Gets games that exactly match the given title.
    /// </summary>
    /// <param name="title">The title to search for.</param>
    /// <returns>Games with an exact title match.</returns>
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<GameDto>>> GetGamesByTitle([FromQuery] string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return BadRequest("Title is required.");

        var games = await _uow.GameRepository.GetAllAsync();
        var matches = games.Where(g => g.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (!matches.Any())
            return NotFound("No games found with that title.");

        return Ok(_mapper.Map<IEnumerable<GameDto>>(matches));
    }

    private async Task<bool> GameExists(int id)
    {
        return await _uow.GameRepository.AnyAsync(id);
    }
}