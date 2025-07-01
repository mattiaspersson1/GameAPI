using System;

namespace Tournament.Core.Dto
{
    public class GameDto
    {
        public required string Title { get; set; }
        public DateTime Time { get; set; }
    }
}