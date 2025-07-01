﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tournament.Core.Entities
{
    public class Tournament
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}