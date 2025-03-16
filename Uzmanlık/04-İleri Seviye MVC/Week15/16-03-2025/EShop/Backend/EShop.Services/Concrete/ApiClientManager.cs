using System.Security.Cryptography;
using EShop.Data.Abstract;
using EShop.Entity.Concrete;
using EShop.Services.Abstract;
using EShop.Shared.Dtos.ResponseDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services.Concrete
{
    public class ApiClientManager : IApiClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApiClientManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<ApiClient>> CreateApiClientAsync(string name, string? description = null)
        {
            try
            {
                var apiKey = GenerateApiKey();
                var apiClient = new ApiClient
                {
                    Name = name,
                    ApiKey = apiKey,
                    Description = description
                };

                await _unitOfWork.GetRepository<ApiClient>().AddAsync(apiClient);
                await _unitOfWork.SaveAsync();

                return ResponseDto<ApiClient>.Success(apiClient, StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return ResponseDto<ApiClient>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<ApiClient>> GetApiClientByKeyAsync(string apiKey)
        {
            try
            {
                var apiClient = await _unitOfWork.GetRepository<ApiClient>()
                    .GetAsync(x => x.ApiKey == apiKey);

                if (apiClient == null)
                {
                    return ResponseDto<ApiClient>.Fail("API Client bulunamadı!", StatusCodes.Status404NotFound);
                }

                return ResponseDto<ApiClient>.Success(apiClient, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<ApiClient>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<List<ApiClient>>> GetAllApiClientsAsync()
        {
            try
            {
                var apiClients = await _unitOfWork.GetRepository<ApiClient>()
                    .GetAllAsync();

                return ResponseDto<List<ApiClient>>.Success(apiClients.ToList(), StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<List<ApiClient>>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<NoContent>> DeactivateApiClientAsync(string apiKey)
        {
            try
            {
                var apiClient = await _unitOfWork.GetRepository<ApiClient>()
                    .GetAsync(x => x.ApiKey == apiKey);

                if (apiClient == null)
                {
                    return ResponseDto<NoContent>.Fail("API Client bulunamadı!", StatusCodes.Status404NotFound);
                }

                apiClient.IsActive = false;
                await _unitOfWork.SaveAsync();

                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<NoContent>> ActivateApiClientAsync(string apiKey)
        {
            try
            {
                var apiClient = await _unitOfWork.GetRepository<ApiClient>()
                    .GetAsync(x => x.ApiKey == apiKey);

                if (apiClient == null)
                {
                    return ResponseDto<NoContent>.Fail("API Client bulunamadı!", StatusCodes.Status404NotFound);
                }

                apiClient.IsActive = true;
                await _unitOfWork.SaveAsync();

                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        private string GenerateApiKey()
        {
            var key = new byte[16];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(key);
                return Convert.ToBase64String(key).Replace("/", "_").Replace("+", "-").Replace("=", "");
            }
        }
    }
}