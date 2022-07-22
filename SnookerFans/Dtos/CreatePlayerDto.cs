using System.ComponentModel.DataAnnotations;

namespace SnookerFans.Dtos
{
    public class CreatePlayerDto
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Nationality { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;
    }
}
