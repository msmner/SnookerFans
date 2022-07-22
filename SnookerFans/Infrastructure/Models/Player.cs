using System.ComponentModel.DataAnnotations;

namespace SnookerFans.Models
{
    public class Player : BaseModel
    {
        public Player()
        {
            PlayerOneMatches = new List<Match>();
            PlayerTwoMatches = new List<Match>();
        }

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
        public ICollection<Match> PlayerOneMatches { get; set; }

        [Required]
        public ICollection<Match> PlayerTwoMatches { get; set; }

        [Required]
        public string Description { get; set; } = null!;
    }
}
