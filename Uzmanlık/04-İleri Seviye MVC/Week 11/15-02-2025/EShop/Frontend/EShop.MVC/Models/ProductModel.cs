using System;
using System.Text.Json.Serialization;

namespace EShop.MVC.Models
{
    public class ProductModel
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("createDate")]
        public DateTime createDate { get; set; }

        [JsonPropertyName("updatedDate")]
        public DateTime updatedDate { get; set; }

        [JsonPropertyName("isActive")]
        public bool isActive { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool isDeleted { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; } = null!;

        [JsonPropertyName("properties")]
        public string properties { get; set; } = null!;

        [JsonPropertyName("price")]
        public int price { get; set; }

        [JsonPropertyName("imageUrl")]
        public string imageUrl { get; set; } = null!;

        [JsonPropertyName("categories")]
        public List<object> categories { get; set; } = [];
    }
}
