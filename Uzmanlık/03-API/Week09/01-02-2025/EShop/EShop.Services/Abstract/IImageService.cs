using System;
using EShop.Shared.Dtos.ResponseDtos;
using Microsoft.AspNetCore.Http;

namespace EShop.Services.Abstract;

public interface IImageService
{
    Task<ResponseDto<string>> UploadImageAsync(IFormFile image);
    ResponseDto<NoContent> DeleteImage(string imageUrl);
}
