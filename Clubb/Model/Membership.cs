using System.ComponentModel.DataAnnotations;

namespace Clubb.Model
{
    public class Membership
    {
        public int Id { get; set; }

        [Required]
        public string Type { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(100, 10000)]
        public decimal Price { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty;

        [Required]
        public int MemberId { get; set; }

        public Member Member { get; set; } = null!;

        public ICollection<Payment> Payments { get; set; }
            = new List<Payment>();
    }
}
