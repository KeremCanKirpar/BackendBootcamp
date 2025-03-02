using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos
{
    public class OrderItemCreateDto
    {
        [Required(ErrorMessage = "Ürün id bilgisi zorunludur!")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Ürün fiyat bilgisi zorunludur!")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Ürün fiyatı 0'dan büyük olmalıdır!")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Ürün adet bilgisi zorunludur!")]
        [Range(1, 100, ErrorMessage = "En fazla 100 adet ürün eklenebilir!")]
        public int Quantity { get; set; }
    }
}
