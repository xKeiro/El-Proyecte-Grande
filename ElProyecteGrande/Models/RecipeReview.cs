﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models
{
    public class RecipeReview : BaseModel
    {


        [Required]
        public required User User { get; set; }

        [Required]
        public required Recipe Recipe { get; set; }

        [Required]
        [Range(1, 5)]
        public required int Rate { get; set; }

        public string? Review { get; set; }

    }
}
