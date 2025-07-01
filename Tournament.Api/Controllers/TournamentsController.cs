using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tournament.Core.Repositories;
using Tournament.Core.Dto;
using TournamentEntity = Tournament.Core.Entities.Tournament;
using AutoMapper;

namespace Tournament.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TournamentsController : ControllerBase
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;

    public TournamentsController(IUoW uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets all tournaments.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TournamentDto>>> GetTournaments()
    {
        var tournaments = await _uow.TournamentRepository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<TournamentDto>>(tournaments));
    }

    /// <summary>
    /// Gets a specific tournament by its ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<TournamentDto>> GetTournament(int id)
    {
        var tournament = await _uow.TournamentRepository.GetAsync(id);
        if (tournament == null)
            return NotFound();

        return Ok(_mapper.Map<TournamentDto>(tournament));
    }

    /// <summary>
    /// Updates an existing tournament.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTournament(int id, TournamentEntity tournament)
    {
        if (id != tournament.Id)
            return BadRequest("ID in URL doesn't match body");

        if (!await _uow.TournamentRepository.AnyAsync(id))
            return NotFound();

        var existing = await _uow.TournamentRepository.GetAsync(id);
        if (existing == null)
            return NotFound();

        existing.Title = tournament.Title;
        existing.StartDate = tournament.StartDate;

        await _uow.CompleteAsync();

        var dto = _mapper.Map<TournamentDto>(existing);
        return Ok(dto);
    }

    /// <summary>
    /// Creates a new tournament.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<TournamentDto>> PostTournament(TournamentEntity tournament)
    {
        _uow.TournamentRepository.Add(tournament);
        await _uow.CompleteAsync();

        var dto = _mapper.Map<TournamentDto>(tournament);
        return CreatedAtAction(nameof(GetTournament), new { id = tournament.Id }, dto);
    }

    /// <summary>
    /// Deletes a tournament by its ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTournament(int id)
    {
        var tournament = await _uow.TournamentRepository.GetAsync(id);
        if (tournament == null)
            return NotFound();

        _uow.TournamentRepository.Remove(tournament);
        await _uow.CompleteAsync();

        return NoContent();
    }

    /// <summary>
    /// Updates only the title of a tournament (partial update).
    /// </summary>
    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchTournamentTitle(int id, [FromBody] string newTitle)
    {
        if (string.IsNullOrWhiteSpace(newTitle))
            return BadRequest("Title cannot be empty.");

        var tournament = await _uow.TournamentRepository.GetAsync(id);
        if (tournament == null)
            return NotFound();

        tournament.Title = newTitle;
        await _uow.CompleteAsync();

        return NoContent();
    }

    private async Task<bool> TournamentExists(int id)
    {
        return await _uow.TournamentRepository.AnyAsync(id);
    }
}