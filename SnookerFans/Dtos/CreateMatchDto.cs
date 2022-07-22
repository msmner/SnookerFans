using SnookerFans.Models;
using System.ComponentModel.DataAnnotations;

namespace SnookerFans.Dtos
{
    public class CreateMatchDto
    {
        [Required]
        public string PlayerOneUserName { get; set; } = null!;

        [Required]
        public string PlayerTwoUserName { get; set; } = null!;

        [Required]
        public string Score { get; set; } = null!;

        [Required]
        public int PlayerOneCenturyBreaks { get; set; }

        [Required]
        public int PlayerTwoCenturyBreaks { get; set; }

        [Required]
        public int PlayerTwoHalfCenturyBreaks { get; set; }

        [Required]
        public int PlayerOneHalfCenturyBreaks { get; set; }

        [Required]
        public int PlayerOneMaximums { get; set; }

        [Required]
        public int PlayerTwoMaximums { get; set; }

        [Required]
        public string Description { get; set; } = null!;
    }
}
