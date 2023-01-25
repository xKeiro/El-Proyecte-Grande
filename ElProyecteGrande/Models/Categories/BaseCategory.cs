﻿using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.Categories;

public abstract class BaseCategory : BaseModel
{
    [Required]
    [StringLength(20, MinimumLength = 2)]
    public required string Name { get; set; }
}