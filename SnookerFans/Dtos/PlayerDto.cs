using System.ComponentModel.DataAnnotations;

namespace SnookerFans.Dtos
{
    public class PlayerDto
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public int LifeTimeMaximums { get; set; }

        [Required]
        public int CenturyBreaks { get; set; }

        [Required]
        public int HalfCenturyBreaks { get; set; }

        [Required]
        public string Nationality { get; set; } = null!;

        [Required]
        public int Wins { get; set; }

        [Required]
        public string Description { get; set; } = null!;
    }
}
