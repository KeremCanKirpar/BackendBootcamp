using System;
using System.Text.Json.Serialization;

namespace EShop.MVC.Models
{
    public class ProductModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("createDate")]
        public DateTime CreateDate { get; set; }

        [JsonPropertyName("updatedDate")]
        public DateTime UpdatedDate { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("properties")]
        public string Properties { get; set; } = null!;

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; } = null!;

        [JsonPropertyName("categories")]
        public List<CategoryModel> Categories { get; set; } = [];
    }
}
