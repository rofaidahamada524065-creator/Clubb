using System.ComponentModel.DataAnnotations;

namespace Clubb.Model
{
    public class Facility
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1, 100)]
        public int Capacity { get; set; }

        [Required]
        [Range(50, 10000)]
        public decimal HourlyPrice { get; set; }

        public ICollection<Booking> Bookings { get; set; }
            = new List<Booking>();
    }
}
