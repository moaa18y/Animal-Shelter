using System;

namespace AnimalShelter.src.Shared.Dto.UserDtos
{
    // Shared DTOs for controllers (lightweight adapters)
    public class SimpleUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
