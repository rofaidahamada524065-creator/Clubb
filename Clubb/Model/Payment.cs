using System.ComponentModel.DataAnnotations;

namespace Clubb.Model
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        [Range(100, 10000)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public string PaymentMethod { get; set; } = string.Empty;

        [Required]
        public int MembershipId { get; set; }

        public Membership Membership { get; set; } = null!;
    }
}
