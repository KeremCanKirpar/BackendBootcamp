1) Kategori oluşturma promptu:

using System;

namespace EShop.Entity.Abstract;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; }
}

using System;
using EShop.Entity.Abstract;

namespace EShop.Entity.Concrete;

public class Category : BaseEntity
{
    private Category()//EF Core için
    {

    }
    public Category(string name, string imageUrl)
    {
        Name = name;
        ImageUrl = imageUrl;
    }

    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; } = new HashSet<ProductCategory>();

}
Category entityme ait, 10 örnek veri yaratacak HasData komutunu hazırlamanı istiyorum. 
Bu proje bir eticaret projesi, kategori isimlerini buna göre belirle. Bir de bir kaç kelimeden oluşan açıklamalar yazmayı ihmal etme.
1den başlayarak birer birer artacak şekilde Id değerleri ver.
NavigationProperty ile ilgili bir veri girişi yapmana gerek yok.
10 kategoriden 2 tanesinin IsActive değeri false olsun, 2 tanesinin ise IsDeleted değeri true olsun.

