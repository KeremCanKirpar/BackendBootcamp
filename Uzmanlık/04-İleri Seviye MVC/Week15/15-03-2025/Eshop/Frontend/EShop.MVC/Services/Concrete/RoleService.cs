using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;

namespace EShop.MVC.Services.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly IHttpClientService _httpClientService;

        public RoleService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ResponseModel<List<RoleModel>>> GetAllAsync()
        {
            try
            {
                var response = await _httpClientService.GetAsync<ResponseModel<List<RoleModel>>>("roles");
                return response ?? new ResponseModel<List<RoleModel>> { Error = "Sunucudan yanıt alınamadı." };
            }
            catch (Exception ex)
            {
                return new ResponseModel<List<RoleModel>> { Error = ex.Message };
            }
        }

        public async Task<ResponseModel<NoContent>> CreateAsync(string roleName)
        {
            try
            {
                var request = new { name = roleName };
                var response = await _httpClientService.PostAsync<object, ResponseModel<NoContent>>("roles", request);
                return response ?? new ResponseModel<NoContent> { Error = "Sunucudan yanıt alınamadı." };
            }
            catch (Exception ex)
            {
                return new ResponseModel<NoContent> { Error = ex.Message };
            }
        }

        public async Task<ResponseModel<NoContent>> DeleteAsync(string id)
        {
            try
            {
                var response = await _httpClientService.DeleteAsync<ResponseModel<NoContent>>($"roles/{id}");
                return response ?? new ResponseModel<NoContent> { Error = "Sunucudan yanıt alınamadı." };
            }
            catch (Exception ex)
            {
                return new ResponseModel<NoContent> { Error = ex.Message };
            }
        }
    }
}