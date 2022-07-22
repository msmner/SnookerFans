using System.ComponentModel.DataAnnotations;

namespace SnookerFans.Models
{
    public abstract class BaseModel
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
