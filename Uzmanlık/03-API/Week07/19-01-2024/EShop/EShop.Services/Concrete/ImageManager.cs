using System;
using EShop.Services.Abstract;
using EShop.Shared.Dtos.ResponseDtos;
using Microsoft.AspNetCore.Http;

namespace EShop.Services.Concrete;

public class ImageManager : IImageService
{
    private readonly string _imageFolderPath;
    public ImageManager()
    {
       
        _imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        if (!Directory.Exists(_imageFolderPath))
        {
            Directory.CreateDirectory(_imageFolderPath);
        }
    }
    public ResponseDto<NoContent> DeleteImage(string imageUrl)
    {
        try
        {
            if(string.IsNullOrWhiteSpace(imageUrl))
            {
                return ResponseDto<NoContent>.Fail("Resim yolu boş olamaz!", StatusCodes.Status400BadRequest);
            }
            var fileName = Path.GetFileName(imageUrl);
            var fileFullPath = Path.Combine(_imageFolderPath, fileName);
            if(!File.Exists(fileFullPath))
            {
                return ResponseDto<NoContent>.Fail("Resim dosyası bulunamadı!", StatusCodes.Status404NotFound);
            }
            File.Delete(fileFullPath);
            return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            
            return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDto<string>> UploadImageAsync(IFormFile image)
    {
        try
        {
            if (image == null)
            {
                return ResponseDto<string>.Fail("Resim dosyası boş olamaz!", StatusCodes.Status400BadRequest);
            }

            if (image.Length == 0)
            {
                return ResponseDto<string>.Fail("Resim dosyası 0 byte'tan büyük olmalıdır.", StatusCodes.Status400BadRequest);
            }

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
            var imageExtension = Path.GetExtension(image.FileName);//.png
            if (!allowedExtensions.Contains(imageExtension))
            {
                return ResponseDto<string>.Fail("Uygunsuz dosya uzantısı. Uygulanabilir uzantılar: .jpg, .jpeg, .png, .bmp, .gif", StatusCodes.Status400BadRequest);
            }

            if (image.Length > 5 * 1024 * 1024)
            {
                return ResponseDto<string>.Fail("Resim dosyası 5MB'dan büyük olamaz.", StatusCodes.Status400BadRequest);
            }

            var fileName = $"{Guid.NewGuid()}{imageExtension}";
            var fileFullPath = Path.Combine(_imageFolderPath, fileName);//C
            using (var stream = new FileStream(fileFullPath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
            return ResponseDto<string>.Success($"/images/{fileName}", StatusCodes.Status201Created);
        }
        catch (Exception ex)
        {
            return ResponseDto<string>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

}
