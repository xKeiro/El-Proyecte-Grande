using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ElProyecteGrande.Models.Enums;

namespace ElProyecteGrande.Models.Users
{
    public class UserRecipeStatus : BaseModel
    {
        [Required]
        public required RecipeStatus Name { get; set; }
    }
}
