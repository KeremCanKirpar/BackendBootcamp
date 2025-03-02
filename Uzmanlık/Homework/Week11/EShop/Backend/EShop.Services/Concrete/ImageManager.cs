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
        //C:\Users\enginniyazi\Documents\GitHub\10-BE-UZMANLIK-YY\03-API\Week07\19-01-2024\EShop\EShop.API\wwwroot\images
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
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                return ResponseDto<NoContent>.Fail("Resim yolu boş olamaz!", StatusCodes.Status400BadRequest);
            }

            var fileName = Path.GetFileName(imageUrl);//48d2770e-e8c4-4590-b2b0-b88327dcc10b.png
            var fileFullPath = Path.Combine(_imageFolderPath, fileName);//C:\Users\enginniyazi\Documents\GitHub\10-BE-UZMANLIK-YY\03-API\Week07\19-01-2024\EShop\EShop.API\wwwroot\images\48d2770e-e8c4-4590-b2b0-b88327dcc10b.png

            if (!File.Exists(fileFullPath))
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

            var fileName = $"{Guid.NewGuid()}{imageExtension}";//48d2770e-e8c4-4590-b2b0-b88327dcc10b.png
            var fileFullPath = Path.Combine(_imageFolderPath, fileName);//C:\Users\enginniyazi\Documents\GitHub\10-BE-UZMANLIK-YY\03-API\Week07\19-01-2024\EShop\EShop.API\wwwroot\images\48d2770e-e8c4-4590-b2b0-b88327dcc10b.png
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
