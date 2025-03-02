using System;
using AutoMapper;
using EShop.Data.Abstract;
using EShop.Entity.Concrete;
using EShop.Services.Abstract;
using EShop.Shared.Dtos;
using EShop.Shared.Dtos.ResponseDtos;
using Microsoft.AspNetCore.Http;

namespace EShop.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IImageService _imageManager;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryRepository = _unitOfWork.GetRepository<Category>();
            _imageManager = imageManager;
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
                var imageResponse = await _imageManager.UploadImageAsync(categoryCreateDto.Image);
                if (!imageResponse.IsSuccessful)
                {
                    return ResponseDto<CategoryDto>.Fail(imageResponse.Error, imageResponse.StatusCode);
                }
                category.ImageUrl = imageResponse.Data ?? "/images/default-category.png";

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

        public async Task<ResponseDto<int>> CountAsync()
        {
            try
            {
                var count = await _categoryRepository.CountAsync();
                return ResponseDto<int>.Success(count, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<int>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }

        }

        public async Task<ResponseDto<int>> CountAsync(bool? isActive)
        {
            try
            {
                var count = await _categoryRepository.CountAsync(x => x.IsActive == isActive);
                return ResponseDto<int>.Success(count, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<int>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }

        }

        public async Task<ResponseDto<IEnumerable<CategoryDto>>> GetAllAsync()
        {
            try
            {
                var categories = await _categoryRepository.GetAllAsync();
                if (!categories.Any())
                {
                    return ResponseDto<IEnumerable<CategoryDto>>.Fail("Kategori bulunamadı!", StatusCodes.Status404NotFound);
                }
                var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);
                return ResponseDto<IEnumerable<CategoryDto>>.Success(categoryDtos, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<IEnumerable<CategoryDto>>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<IEnumerable<CategoryDto>>> GetAllAsync(bool isActive)
        {
            try
            {
                var categories = await _categoryRepository.GetAllAsync(x => x.IsActive == isActive);
                if (!categories.Any())
                {
                    var messageTitle = isActive == true ? "Aktif" : "Pasif";
                    return ResponseDto<IEnumerable<CategoryDto>>.Fail($"{messageTitle} kategori bulunamadı!", StatusCodes.Status404NotFound);
                }
                var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);
                return ResponseDto<IEnumerable<CategoryDto>>.Success(categoryDtos, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<IEnumerable<CategoryDto>>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<CategoryDto>> GetAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetAsync(x => x.Id == id);
                if (category == null)
                {
                    return ResponseDto<CategoryDto>.Fail("Kategori bulunamadı!", StatusCodes.Status404NotFound);
                }
                var categoryDto = _mapper.Map<CategoryDto>(category);
                return ResponseDto<CategoryDto>.Success(categoryDto, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<CategoryDto>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<NoContent>> HardDeleteAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetAsync(x => x.Id == id);
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
                return ResponseDto<NoContent>.Success(StatusCodes.Status204NoContent);

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
                var category = await _categoryRepository.GetAsync(x => x.Id == id);
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

                var existsCategoryName = await _categoryRepository.ExistsAsync(x => x.Name.ToLower() == categoryUpdateDto.Name.ToLower());
                if (existsCategoryName)
                {
                    return ResponseDto<NoContent>.Fail("Bu adda kategori mevcut!", StatusCodes.Status400BadRequest);
                }
                //Resim operasyonu
                if (categoryUpdateDto.Image != null)
                {
                    var imageResponse = await _imageManager.UploadImageAsync(categoryUpdateDto.Image);
                    if (!imageResponse.IsSuccessful)
                    {
                        return ResponseDto<NoContent>.Fail(imageResponse.Error, imageResponse.StatusCode);
                    }
                    _imageManager.DeleteImage(category.ImageUrl);
                    category.ImageUrl = imageResponse.Data ?? "/images/default-category.png";

                }
                _mapper.Map(categoryUpdateDto, category);
                _categoryRepository.Update(category);
                var result = await _unitOfWork.SaveAsync();
                if (result < 1)
                {
                    return ResponseDto<NoContent>.Fail("Kategori güncellenirken bir hata oluştu!", StatusCodes.Status500InternalServerError);
                }
                return ResponseDto<NoContent>.Success(StatusCodes.Status204NoContent);
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
                var hasProducts = await _unitOfWork.GetRepository<ProductCategory>().ExistsAsync(x => x.CategoryId == id);
                if (hasProducts)
                {
                    return ResponseDto<bool>.Fail("Bu kategoriye ait ürünler olduğu için pasif hale getirilemez!", StatusCodes.Status400BadRequest);
                }
                category.IsActive = !category.IsActive;
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
    }
}
