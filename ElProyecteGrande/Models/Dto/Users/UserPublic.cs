namespace ElProyecteGrande.Models.Dto.Users
{
    public class UserPublic
    {
        public required int Id { get; set; }
        public required string Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public required string EmailAddress { get; set; }

        public bool IsAdmin { get; set; }
    }
}
