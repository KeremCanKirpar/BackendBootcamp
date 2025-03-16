using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EShop.MVC.Models;

public class ProductCreateModel
{
    [Required(ErrorMessage = "Ürün adı zorunludur.")]
    [StringLength(100, ErrorMessage = "Ürün adı en fazla 100 karakter olmalıdır.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Ürün özellikleri zorunludur.")]
    [StringLength(10000, ErrorMessage = "Ürün özellikleri en fazla 10000 karakter olmalıdır.")]
    public string? Properties { get; set; }

    /*
        REGEX
        KARAKTER SINIFLARI
        1) . : Herhangi bir tek karakter
        2) [abc]: Sadece a,b ya da c karakterlerinden biri
        3) [^abc]: a,b ya da c dışındaki herhangi bir karakter
        4) [a-z]: Küçük harflerden biri
        5) [A-Z]: Büyük harflerden biri
        6) [0-9]: Rakamlardan biri
        ÖZEL KARAKTERLER
        1) \d : Bir rakam(0-9)
        2) \D : Rakam dışında bir karakter
        3) \w : Harf, rakam ya da alt çizgi(a-z, A-Z, 0-9, _)
        4) \W : Harf, rakam ya da alt çizgi dışında bir karakter
        5) \s : Boşluk karakteri
        6) \S : Boşluk dışında bir karakter
        TEKRARLAMA OPERATORLERİ
        1) * : 0 ya da daha fazla tekrar
        2) + : 1 ya da daha fazla tekrar
        3) ? : 0 ya da 1 tekrar
        4) {n} : Tam olarak n tekrar
        5) {n,} : En az n tekrar
        6) {n,m} : En az n, en çok m tekrar
        BAŞLANGIÇ/BİTİŞ OPERATÖRLERİ
        1) ^ : Metnin başlangıcı
        2) $ : Metnin bitişi

    */

    [Required(ErrorMessage = "Ürün fiyatı zorunludur.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Ürün fiyatı 0'dan büyük olmalıdır.")]
    [RegularExpression(@"^\d+([.,]\d{1,2})?$", ErrorMessage = "Ürün fiyatı geçerli bir sayı olmalıdır.")]
    public decimal? Price { get; set; }

    [Display(Name = "Ürün Resmi")]
    public IFormFile? Image { get; set; }

    [Required(ErrorMessage = "Her ürün için en az bir kategori zorunludur.")]
    public ICollection<int> CategoryIds { get; set; } = new List<int>();

    [Display(Name = "Anasayfada Gösterilsin mi?")]
    public bool IsHome { get; set; }

}