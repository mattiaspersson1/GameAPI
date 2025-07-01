using System;

namespace Tournament.Api.Dto
{
    public class UpdateGameDto
    {
        public string Title { get; set; }
        public DateTime Time { get; set; }
        public int TournamentId { get; set; }
    }
}