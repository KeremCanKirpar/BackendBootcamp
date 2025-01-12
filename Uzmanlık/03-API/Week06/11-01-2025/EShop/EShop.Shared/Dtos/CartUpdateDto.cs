using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos;

public class CartUpdateDto
{  
    public int Id { get; set; }
    [Required(ErrorMessage = "Kategori Aktif/Pasif Durumu Zorunludur!")]
    public bool IsActive { get; set; }
    [Required(ErrorMessage = "Kategori Silinme Durumu Zorunludur!")]
    public bool IsDeleted { get; set; }

}
