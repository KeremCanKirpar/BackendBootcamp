using System.Linq.Expressions;
using AutoMapper;
using EShop.Data.Abstract;
using EShop.Entity.Concrete;
using EShop.Services.Abstract;
using EShop.Shared.Dtos.CategoryDtos;
using EShop.Shared.Dtos.ResponseDtos;
using Microsoft.AspNetCore.Http;

namespace EShop.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;
        private readonly IProductService _productManager;
        private readonly IImageService _imageManager;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageManager, IProductService productManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryRepository = _unitOfWork.GetRepository<Category>();
            _productRepository = _unitOfWork.GetRepository<Product>();
            _productCategoryRepository = _unitOfWork.GetRepository<ProductCategory>();
            _imageManager = imageManager;
            _productManager = productManager;
        }

        public async Task<ResponseDto<CategoryDto>> AddAsync(CategoryCreateDto categoryCreateDto)
        {
            try
            {
                var isExists = await _categoryRepository.ExistsAsync(x => x.Name.ToLower() == categoryCreateDto.Name.ToLower());
                if (isExists)
                {
                    return ResponseDto<CategoryDto>.Fail("Bu adda kategori mevcut!", StatusCodes.Status400BadRequest);
                }
                var category = _mapper.Map<Category>(categoryCreateDto);
                //Resim Yükleme
                if (categoryCreateDto.Image == null)
                {
                    return ResponseDto<CategoryDto>.Fail("Kategori resmi boş olamaz!", StatusCodes.Status400BadRequest);
                }
                var imageResponse = await _imageManager.UploadImageAsync(categoryCreateDto.Image, "categories");
                if (!imageResponse.IsSuccessful)
                {
                    return ResponseDto<CategoryDto>.Fail(imageResponse.Error!, imageResponse.StatusCode);
                }
                category.ImageUrl = imageResponse.Data ?? "/images/categories/default-category.png";

                await _categoryRepository.AddAsync(category);
                var result = await _unitOfWork.SaveAsync();
                if (result < 1)
                {
                    return ResponseDto<CategoryDto>.Fail("Kategori eklenirken bir hata oluştu!", StatusCodes.Status500InternalServerError);
                }
                var categoryDto = _mapper.Map<CategoryDto>(category);
                return ResponseDto<CategoryDto>.Success(categoryDto, StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return ResponseDto<CategoryDto>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<NoContent>> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            try
            {
                var category = await _categoryRepository.GetAsync(x => x.Id == categoryUpdateDto.Id);
                if (category == null)
                {
                    return ResponseDto<NoContent>.Fail("Kategori bulunamadığı için güncellenemedi!", StatusCodes.Status404NotFound);
                }
                if (!category.IsActive)
                {
                    return ResponseDto<NoContent>.Fail("Pasif kategoriler güncellenemez! Önce güncellemek istediğiniz kategoriyo Aktif duruma getirmeniz gerekir!", StatusCodes.Status400BadRequest);
                }

                //Resim operasyonu
                if (categoryUpdateDto.Image != null)
                {
                    var imageResponse = await _imageManager.UploadImageAsync(categoryUpdateDto.Image, "categories");
                    if (!imageResponse.IsSuccessful)
                    {
                        return ResponseDto<NoContent>.Fail(imageResponse.Error!, imageResponse.StatusCode);
                    }
                    _imageManager.DeleteImage(category.ImageUrl);
                    category.ImageUrl = imageResponse.Data!;

                }
                _mapper.Map(categoryUpdateDto, category);
                category.UpdatedAt = DateTime.UtcNow;
                _categoryRepository.Update(category);
                var result = await _unitOfWork.SaveAsync();
                if (result < 1)
                {
                    return ResponseDto<NoContent>.Fail("Kategori güncellenirken bir hata oluştu!", StatusCodes.Status500InternalServerError);
                }
                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<NoContent>> HardDeleteAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetAsync(predicate: x => x.Id == id, showIsDeleted: true);
                if (category == null)
                {
                    return ResponseDto<NoContent>.Fail("Kategori bulunamadığı için silinemedi!", StatusCodes.Status404NotFound);
                }
                var hasProducts = await _unitOfWork.GetRepository<ProductCategory>().ExistsAsync(x => x.CategoryId == id);
                if (hasProducts)
                {
                    return ResponseDto<NoContent>.Fail("Bu kategoriye ait ürünler olduğu için silinemez! Önce ürünleri silmeniz ya da kategorisini değiştirmeniz gerekmektedir!", StatusCodes.Status400BadRequest);
                }

                _categoryRepository.Delete(category);
                var result = await _unitOfWork.SaveAsync();
                if (result < 1)
                {
                    return ResponseDto<NoContent>.Fail("Kategori silinirken bir hata oluştu!", StatusCodes.Status500InternalServerError);
                }
                _imageManager.DeleteImage(category.ImageUrl);
                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<NoContent>> SoftDeleteAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetAsync(predicate: x => x.Id == id, showIsDeleted: true);
                if (category == null)
                {
                    return ResponseDto<NoContent>.Fail("Kategori bulunamadığı için silme ya da geri alma işlemi yapılamadı!", StatusCodes.Status404NotFound);
                }
                var hasProducts = await _unitOfWork.GetRepository<ProductCategory>().ExistsAsync(x => x.CategoryId == id);
                if (hasProducts)
                {
                    return ResponseDto<NoContent>.Fail("Bu kategoriye ait ürünler olduğu için silme işlemi yapılamaz!", StatusCodes.Status400BadRequest);
                }
                category.IsDeleted = !category.IsDeleted;
                if (category.IsDeleted) category.IsActive = false;
                category.DeletedAt = DateTime.UtcNow;
                _categoryRepository.Update(category);
                var result = await _unitOfWork.SaveAsync();
                if (result < 1)
                {
                    return ResponseDto<NoContent>.Fail("Kategori silinmeye ya da geri alınmaya çalışışırken bir hata oluştu!", StatusCodes.Status500InternalServerError);
                }
                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<bool>> UpdateIsActiveAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetAsync(x => x.Id == id);
                if (category == null)
                {
                    return ResponseDto<bool>.Fail("Kategori bulunamadığı için aktiflik durumu güncellenemedi!", StatusCodes.Status404NotFound);
                }
                var hasProduct = await _productCategoryRepository.ExistsAsync(x => x.CategoryId == id);
                if (hasProduct)
                {
                    // return ResponseDto<bool>.Fail("Bu kategoriye ait ürünler olduğu için pasif hale getirilemez!", StatusCodes.Status400BadRequest);
                    await _productManager.UpdateIsActiveByCategoryAsync(id);
                }
                category.IsActive = !category.IsActive;
                category.UpdatedAt = DateTime.UtcNow;
                _categoryRepository.Update(category);
                var result = await _unitOfWork.SaveAsync();
                if (result < 1)
                {
                    return ResponseDto<bool>.Fail("Kategori aktiflik durumu güncellenirken bir hata oluştu!", StatusCodes.Status500InternalServerError);
                }
                return ResponseDto<bool>.Success(category.IsActive, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<bool>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<bool>> UpdateIsMenuItemAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetAsync(x => x.Id == id);
                if (category == null)
                {
                    return ResponseDto<bool>.Fail("Kategori bulunamadığı için menüde görünme durumu güncellenemedi!", StatusCodes.Status404NotFound);
                }
                category.IsMenuItem = !category.IsMenuItem;
                category.UpdatedAt = DateTime.UtcNow;
                _categoryRepository.Update(category);
                var result = await _unitOfWork.SaveAsync();
                if (result < 1)
                {
                    return ResponseDto<bool>.Fail("Kategori menüde görünme durumu güncellenirken bir hata oluştu!", StatusCodes.Status500InternalServerError);
                }
                return ResponseDto<bool>.Success(category.IsActive, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<bool>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<CategoryDto>> GetAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetAsync(x => x.Id == id);
                if (category == null)
                {
                    return ResponseDto<CategoryDto>.Fail("Kategori bulunamadı.", StatusCodes.Status404NotFound);
                }
                var categoryDto = _mapper.Map<CategoryDto>(category);

                // Resim kontrolü
                if (!_imageManager.ImageExists(categoryDto.ImageUrl!))
                {
                    categoryDto.ImageUrl = _imageManager.GetDefaultImage("categories");
                }

                return ResponseDto<CategoryDto>.Success(categoryDto, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<CategoryDto>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<IEnumerable<CategoryDto>>> GetAllAsync(bool? isActive = null, bool? isDeleted = null)
        {
            try
            {
                Expression<Func<Category, bool>> predicate = x => true;
                if (isActive.HasValue)
                {
                    predicate = x => x.IsActive == isActive.Value;
                }

                if (isDeleted.HasValue)
                {
                    predicate = isActive.HasValue
                        ? x => x.IsActive == isActive.Value && x.IsDeleted == isDeleted.Value
                        : x => x.IsDeleted == isDeleted.Value;
                }

                var categories = await _categoryRepository.GetAllAsync(predicate: predicate, showIsDeleted: isDeleted ?? false);
                if (!categories.Any())
                {
                    return ResponseDto<IEnumerable<CategoryDto>>.Fail("Hiçbir kategori bulunamadı.", StatusCodes.Status404NotFound);
                }
                var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);

                // Resim kontrolü
                foreach (var categoryDto in categoryDtos)
                {
                    if (!_imageManager.ImageExists(categoryDto.ImageUrl!))
                    {
                        categoryDto.ImageUrl = _imageManager.GetDefaultImage("categories");
                    }
                }

                return ResponseDto<IEnumerable<CategoryDto>>.Success(categoryDtos, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<IEnumerable<CategoryDto>>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }

        }

        public async Task<ResponseDto<int>> CountAsync(bool? isActive = null)
        {
            try
            {
                Expression<Func<Category, bool>> predicate = x => true;
                if (isActive.HasValue)
                {
                    predicate = x => x.IsActive == isActive.Value;
                }
                var count = await _categoryRepository.CountAsync(predicate);
                return ResponseDto<int>.Success(count, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<int>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }

        }

        public async Task<ResponseDto<IEnumerable<CategoryDto>>> GetMenuItemsAsync()
        {
            try
            {
                var categories = await _categoryRepository.GetAllAsync(predicate: x => x.IsMenuItem);
                if (!categories.Any())
                {
                    return ResponseDto<IEnumerable<CategoryDto>>.Fail("Hiçbir kategori bulunamadı.", StatusCodes.Status404NotFound);
                }
                var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);

                // Resim kontrolü
                foreach (var categoryDto in categoryDtos)
                {
                    if (!_imageManager.ImageExists(categoryDto.ImageUrl!))
                    {
                        categoryDto.ImageUrl = _imageManager.GetDefaultImage("categories");
                    }
                }

                return ResponseDto<IEnumerable<CategoryDto>>.Success(categoryDtos, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<IEnumerable<CategoryDto>>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }

        }
    }
}
