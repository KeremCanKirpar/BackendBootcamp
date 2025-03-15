using EShop.MVC.Models;

namespace EShop.MVC.Services.Abstract
{
    public interface IUserService
    {
        /// <summary>
        /// Tüm kullanıcıları getirir.
        /// </summary>
        /// <returns>Kullanıcı listesi</returns>
        Task<ResponseModel<List<UserModel>>> GetAllAsync();

        /// <summary>
        /// Id'ye göre kullanıcı getirir.
        /// </summary>
        /// <param name="id">Kullanıcı id</param>
        /// <returns>Kullanıcı</returns>
        Task<ResponseModel<UserModel>> GetByIdAsync(string id);

        /// <summary>
        /// Kullanıcının rollerini günceller.
        /// </summary>
        /// <param name="userId">Kullanıcı id</param>
        /// <param name="roles">Rol listesi</param>
        /// <returns>İşlem sonucu</returns>
        Task<ResponseModel<NoContent>> UpdateRolesAsync(string userId, List<string> roles);

        /// <summary>
        /// Giriş yapmış kullanıcının profilini getirir.
        /// </summary>
        /// <returns>Kullanıcı profili</returns>
        Task<ResponseModel<UserModel>> GetMyProfileAsync();

        /// <summary>
        /// Giriş yapmış kullanıcının profilini günceller.
        /// </summary>
        /// <param name="model">Güncellenecek profil bilgileri</param>
        /// <returns>İşlem sonucu</returns>
        Task<ResponseModel<NoContent>> UpdateMyProfileAsync(UserUpdateModel model);
    }
}