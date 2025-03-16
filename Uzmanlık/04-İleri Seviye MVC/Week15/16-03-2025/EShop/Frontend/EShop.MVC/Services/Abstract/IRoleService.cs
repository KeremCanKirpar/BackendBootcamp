using EShop.MVC.Models;

namespace EShop.MVC.Services.Abstract
{
    public interface IRoleService
    {
        /// <summary>
        /// Tüm rolleri getirir.
        /// </summary>
        /// <returns>Rol listesi</returns>
        Task<ResponseModel<List<RoleModel>>> GetAllAsync();

        /// <summary>
        /// Yeni rol oluşturur.
        /// </summary>
        /// <param name="roleName">Rol adı</param>
        /// <returns>İşlem sonucu</returns>
        Task<ResponseModel<NoContent>> CreateAsync(string roleName);

        /// <summary>
        /// Id'ye göre rol siler.
        /// </summary>
        /// <param name="id">Rol id</param>
        /// <returns>İşlem sonucu</returns>
        Task<ResponseModel<NoContent>> DeleteAsync(string id);
    }
}