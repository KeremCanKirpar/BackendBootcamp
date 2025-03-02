using EShop.Services.Abstract;
using EShop.Shared.ControllerBases;
using EShop.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : CustomControllerBase
    {
        private readonly IProductService _productManager;

        public ProductsController(IProductService productManager)
        {
            _productManager = productManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductCreateDto productCreateDto)
        {
            //Kategorisiz ürün kaydetme sorunumuz var, ilgileneceğiz.
            var response = await _productManager.AddAsync(productCreateDto);
            return CreateResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            var response = await _productManager.UpdateAsync(productUpdateDto);
            return CreateResult(response);
        }

        [HttpDelete("harddelete/{id}")]
        public async Task<IActionResult> HardDelete(int id)
        {
            var response = await _productManager.HardDeleteAsync(id);
            return CreateResult(response);
        }
        [HttpDelete("softdelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var response = await _productManager.SoftDeleteAsync(id);
            return CreateResult(response);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _productManager.GetAsync(id);
            return CreateResult(response);
        }

        [HttpGet("get/withcategories/{id}")]
        public async Task<IActionResult> GetByIdWithCategories(int id)
        {
            var response = await _productManager.GetWithCategoriesAsync(id);
            return CreateResult(response);
        }

        [HttpGet("get/all")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productManager.GetAllAsync();
            return CreateResult(response);
        }

        [HttpGet("get/all/active")]
        public async Task<IActionResult> GetAll([FromQuery] bool isActive)
        {
            var response = await _productManager.GetAllAsync(isActive);
            return CreateResult(response);
        }

        [HttpGet("get/all/withcategories")]
        public async Task<IActionResult> GetAllWithCategories()
        {
            var response = await _productManager.GetAllWithCategoriesAsync();
            return CreateResult(response);
        }

        [HttpGet("get/all/bycategory")]
        public async Task<IActionResult> GetAllByCategory([FromQuery] int categoryId)
        {
            var response = await _productManager.GetByCategoryAsync(categoryId);
            return CreateResult(response);
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetCount()
        {
            var response = await _productManager.CountAsync();
            return CreateResult(response);
        }

        [HttpGet("count/active")]
        public async Task<IActionResult> GetActivesCount()
        {
            var response = await _productManager.CountAsync(true);
            return CreateResult(response);
        }

        [HttpGet("count/passive")]
        public async Task<IActionResult> GetPassivesCount()
        {
            var response = await _productManager.CountAsync(false);
            return CreateResult(response);
        }

        [HttpPut("updateisactive/{id}")]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var response = await _productManager.UpdateIsActiveAsync(id);
            return CreateResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("get/all/deleted")]
        public async Task<IActionResult> GetAllDeleted()
        {
            var response = await _productManager.GetAllDeletedAsync();
            return CreateResult(response);
        }
    }
}
