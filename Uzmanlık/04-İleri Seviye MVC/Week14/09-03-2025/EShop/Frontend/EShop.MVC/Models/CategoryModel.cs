using System;
using System.Text.Json.Serialization;

namespace EShop.MVC.Models
{
    public class CategoryModel
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

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        // ÖDEV: İlgili kategorideki ürün sayısını veren bir property ekleyelim, bunun için API tarafında yapılması gerekenleri yapalım.
    }
}
