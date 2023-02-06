﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models;

/// <summary>
/// Different type of ingredients, like - onion, penne, tomato etc.
/// </summary>
[Index(nameof(Name), IsUnique = true)]
public class Ingredient : BaseModel
{
    [Required]
    [StringLength(60, MinimumLength = 2)]
    public required string Name { get; set; }

    [Required]
    public required string UnitOfMeasure { get; set; }
}