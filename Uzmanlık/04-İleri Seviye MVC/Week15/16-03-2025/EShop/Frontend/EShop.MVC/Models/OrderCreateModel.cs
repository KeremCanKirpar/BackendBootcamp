using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EShop.MVC.Models
{
    public class OrderCreateModel
    {
        [JsonPropertyName("orderItems")]
        public List<OrderItemCreateModel> OrderItems { get; set; } = [];

        [JsonPropertyName("address")]
        public string Address { get; set; } = "Zeliha hanım mh. Hanönü Cd. Çember Sk. No:10/9";

        [JsonPropertyName("city")]
        public string City { get; set; } = "İstanbul";


        [JsonIgnore]
        public string FirstName { get; set; }="Alex";
        [JsonIgnore]
        public string LastName { get; set; }="De Souza";
        [JsonIgnore]
        public string PhoneNumber { get; set; }="5559998887";
        [JsonIgnore]
        public string Email { get; set; }="alexdesouza@gmail.com";
        [JsonIgnore]
        public string IdentityNumber { get; set; }="5559998887";



        [JsonIgnore]
        public string CardHolderName { get; set; }="Jan De Souza";
        [JsonIgnore]
        public string CardNumber { get; set; }= "5890040000000016";
        [JsonIgnore]
        public string ExpireMonth { get; set; }= "12";
        [JsonIgnore]
        public string ExpireYear { get; set; }= "2030";
        [JsonIgnore]
        public string Cvc { get; set; }= "123";


        [JsonIgnore]
        public decimal TotalAmount => OrderItems.Sum(x => x.UnitPrice * x.Quantity);
    }
}
