using System.Text.Json.Serialization;

namespace EShop.MVC.Models
{
    public class CartItemCreateModel
    {


        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
