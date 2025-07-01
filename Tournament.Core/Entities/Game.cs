using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tournament.Core.Entities
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public DateTime Time { get; set; }

        public int TournamentId { get; set; }

        [JsonIgnore]
        public Tournament Tournament { get; set; }
    }
}