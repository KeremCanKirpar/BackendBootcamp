using EShop.Services.Abstract;
using EShop.Shared.ControllerBases;
using EShop.Shared.Dtos;
using EShop.Shared.Dtos.ProductDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(ProductCreateDto productCreateDto)
        {
            //Kategorisiz ürün kaydetme sorunumuz var, ilgileneceğiz.
            var response = await _productManager.AddAsync(productCreateDto);
            return CreateResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductUpdateDto productUpdateDto)
        {
            productUpdateDto.Id = id;
            var response = await _productManager.UpdateAsync(productUpdateDto);
            return CreateResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDelete(int id)
        {
            var response = await _productManager.HardDeleteAsync(id);
            return CreateResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var response = await _productManager.SoftDeleteAsync(id);
            return CreateResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/active")]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var response = await _productManager.UpdateIsActiveAsync(id);
            return CreateResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/home")]
        public async Task<IActionResult> UpdateIsHome(int id)
        {
            var response = await _productManager.UpdateIsHomeAsync(id);
            return CreateResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, [FromQuery] bool includeCategories = false)
        {
            var response = await _productManager.GetAsync(id, includeCategories);
            return CreateResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool includeCategories = false, [FromQuery] int? categoryId = null)
        {
            var response = await _productManager.GetAllAsync(
                isActive: true,
                includeCategories: includeCategories,
                categoryId: categoryId,
                isDeleted: false
            );
            return CreateResult(response);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public async Task<IActionResult> GetAllForAdmin(
            [FromQuery] bool? isActive = null,
            [FromQuery] bool includeCategories = false,
            [FromQuery] int? categoryId = null,
            [FromQuery] bool? isDeleted = null)
        {
            var response = await _productManager.GetAllAsync(
                isActive: isActive,
                includeCategories: includeCategories,
                categoryId: categoryId,
                isDeleted: isDeleted
            );
            return CreateResult(response);
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count([FromQuery] bool? isActive = null)
        {
            var response = await _productManager.CountAsync(isActive);
            return CreateResult(response);
        }


    }
}
