using EShop.Shared.Dtos.CategoryDtos;

namespace EShop.Shared.Dtos.ProductDtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsHome { get; set; }
        public string? Name { get; set; }
        public string? Properties { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<CategoryDto> Categories { get; set; } = [];
    }
}
