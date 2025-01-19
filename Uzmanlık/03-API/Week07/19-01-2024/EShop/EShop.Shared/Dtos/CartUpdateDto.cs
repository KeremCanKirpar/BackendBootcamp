using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos;

public class CartUpdateDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Aktif/Pasif durumu zorunludur.")]
    public bool IsActive { get; set; }

    [Required(ErrorMessage = "Silinme durumu zorunludur.")]
    public bool IsDeleted { get; set; }
}
