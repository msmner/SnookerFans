using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnookerFans.Models
{
    public class Match : BaseModel
    {
        [Required]
        public string Score { get; set; } = null!;

        [Required]
        public Guid PlayerOneId { get; set; }

        [Required]
        [InverseProperty("PlayerOneMatches")]
        public Player PlayerOne { get; set; } = null!;

        [Required]
        public Guid PlayerTwoId { get; set; }

        [Required]
        [InverseProperty("PlayerTwoMatches")]
        public Player PlayerTwo { get; set; } = null!;

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
