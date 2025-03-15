using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;

namespace EShop.MVC.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IHttpClientService _httpClientService;

        public UserService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ResponseModel<List<UserModel>>> GetAllAsync()
        {
            try
            {
                var response = await _httpClientService.GetAsync<ResponseModel<List<UserModel>>>("users");
                return response ?? new ResponseModel<List<UserModel>> { Error = "Sunucudan yanıt alınamadı." };
            }
            catch (Exception ex)
            {
                return new ResponseModel<List<UserModel>> { Error = ex.Message };
            }
        }

        public async Task<ResponseModel<UserModel>> GetByIdAsync(string id)
        {
            try
            {
                var response = await _httpClientService.GetAsync<ResponseModel<UserModel>>($"users/{id}");
                return response ?? new ResponseModel<UserModel> { Error = "Sunucudan yanıt alınamadı." };
            }
            catch (Exception ex)
            {
                return new ResponseModel<UserModel> { Error = ex.Message };
            }
        }

        public async Task<ResponseModel<NoContent>> UpdateRolesAsync(string userId, List<string> roles)
        {
            try
            {
                var response = await _httpClientService.PutAsync<List<string>, ResponseModel<NoContent>>($"users/{userId}/roles", roles);
                return response ?? new ResponseModel<NoContent> { Error = "Sunucudan yanıt alınamadı." };
            }
            catch (Exception ex)
            {
                return new ResponseModel<NoContent> { Error = ex.Message };
            }
        }

        public async Task<ResponseModel<UserModel>> GetMyProfileAsync()
        {
            try
            {
                var response = await _httpClientService.GetAsync<ResponseModel<UserModel>>("auth/users/me");
                return response ?? new ResponseModel<UserModel> { Error = "Sunucudan yanıt alınamadı." };
            }
            catch (Exception ex)
            {
                return new ResponseModel<UserModel> { Error = ex.Message };
            }
        }

        public async Task<ResponseModel<NoContent>> UpdateMyProfileAsync(UserUpdateModel model)
        {
            try
            {
                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(model.Id), "Id");
                formData.Add(new StringContent(model.FirstName), "FirstName");
                formData.Add(new StringContent(model.LastName), "LastName");
                formData.Add(new StringContent(model.Email), "Email");
                formData.Add(new StringContent(model.PhoneNumber ?? string.Empty), "PhoneNumber");

                var response = await _httpClientService.PutFormAsync<ResponseModel<NoContent>>("auth/users/me", formData);
                return response ?? new ResponseModel<NoContent> { Error = "Sunucudan yanıt alınamadı." };
            }
            catch (Exception ex)
            {
                return new ResponseModel<NoContent> { Error = ex.Message };
            }
        }
    }
}