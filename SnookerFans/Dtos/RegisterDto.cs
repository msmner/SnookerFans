using System.ComponentModel.DataAnnotations;

namespace SnookerFans.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
