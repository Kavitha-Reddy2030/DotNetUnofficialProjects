using System;

namespace BookFilterAPI.Models.DTO
{
    public class AuthorDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime? Birthdate { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}