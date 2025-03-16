using EShop.Entity.Concrete;
using EShop.Shared.Dtos.ResponseDtos;

namespace EShop.Services.Abstract
{
    public interface IApiClientService
    {
        Task<ResponseDto<ApiClient>> CreateApiClientAsync(string name, string? description = null);
        Task<ResponseDto<ApiClient>> GetApiClientByKeyAsync(string apiKey);
        Task<ResponseDto<List<ApiClient>>> GetAllApiClientsAsync();
        Task<ResponseDto<NoContent>> DeactivateApiClientAsync(string apiKey);
        Task<ResponseDto<NoContent>> ActivateApiClientAsync(string apiKey);
    }
}