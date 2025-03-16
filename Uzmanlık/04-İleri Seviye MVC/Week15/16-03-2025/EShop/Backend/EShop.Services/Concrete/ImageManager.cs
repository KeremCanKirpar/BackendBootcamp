using EShop.Services.Abstract;
using EShop.Shared.Dtos.ResponseDtos;
using Microsoft.AspNetCore.Http;

namespace EShop.Services.Concrete
{
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

        public bool ImageExists(string imageUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(imageUrl)) return false;

                var fileName = imageUrl.Replace("/images/", "");
                var fileFullPath = Path.Combine(_imageFolderPath, fileName);
                return File.Exists(fileFullPath);
            }
            catch
            {
                return false;
            }
        }

        public string GetDefaultImage(string folder)
        {
            if (folder == "categories")
            {
                return $"/images/{folder}/default-category.png";
            }
            return $"/images/{folder}/default-{folder.TrimEnd('s')}.png";
        }

        public void DeleteImage(string imageUrl)
        {
            try
            {
                var fileName = imageUrl.Replace("/images/", "");
                var fileFullPath = Path.Combine(_imageFolderPath, fileName);
                File.Delete(fileFullPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<ResponseDto<string>> UploadImageAsync(IFormFile image, string folder)
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
                var folderPath = Path.Combine(_imageFolderPath, folder);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                var fileFullPath = Path.Combine(folderPath, fileName);
                using (var stream = new FileStream(fileFullPath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                return ResponseDto<string>.Success($"/images/{folder}/{fileName}", StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return ResponseDto<string>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
