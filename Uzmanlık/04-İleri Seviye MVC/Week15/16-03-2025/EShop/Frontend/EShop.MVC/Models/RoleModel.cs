using System.ComponentModel.DataAnnotations;

namespace EShop.MVC.Models
{
    public class RoleModel
    {
        public string Id { get; set; } = null!;

        [Display(Name = "Rol Adı")]
        public string Name { get; set; } = null!;

        [Display(Name = "Kullanıcı Sayısı")]
        public int UserCount { get; set; }
    }
}