using EShop.Shared.Dtos.ResponseDtos;
using Microsoft.AspNetCore.Http;

namespace EShop.Services.Abstract
{
    public interface IImageService
    {
        Task<ResponseDto<string>> UploadImageAsync(IFormFile image, string folder);
        void DeleteImage(string imageUrl);
        bool ImageExists(string imageUrl);
        string GetDefaultImage(string folder);
    }
}
