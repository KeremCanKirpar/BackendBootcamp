using System.ComponentModel.DataAnnotations;

namespace EShop.Entity.Concrete
{
    public class ApiClient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(32)]
        public string ApiKey { get; set; } = null!;

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastUsedAt { get; set; }

        public int RequestCount { get; set; }
    }
}