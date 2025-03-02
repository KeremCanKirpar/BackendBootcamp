using EShop.Services.Abstract;
using EShop.Shared.ControllerBases;
using EShop.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : CustomControllerBase
    {
        private readonly ICategoryService _categoryManager;

        public CategoriesController(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(CategoryCreateDto categoryCreateDto)
        {
            var response = await _categoryManager.AddAsync(categoryCreateDto);
            return CreateResult(response);
        }


        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var response = await _categoryManager.UpdateAsync(categoryUpdateDto);
            return CreateResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("harddelete/{id}")]
        public async Task<IActionResult> HardDelete(int id)
        {
            var response = await _categoryManager.HardDeleteAsync(id);
            return CreateResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("softdelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var response = await _categoryManager.SoftDeleteAsync(id);
            return CreateResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("updateisactive/{id}")]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var response = await _categoryManager.UpdateIsActiveAsync(id);
            return CreateResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryManager.GetAllAsync();
            return CreateResult(response);
        }


        [HttpGet("actives")]
        public async Task<IActionResult> GetActives()
        {
            var response = await _categoryManager.GetAllAsync(true);
            return CreateResult(response);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("passives")]
        public async Task<IActionResult> GetPassives()
        {
            var response = await _categoryManager.GetAllAsync(false);
            return CreateResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _categoryManager.GetAsync(id);
            return CreateResult(response);
        }

        [Authorize("Admin")]
        [HttpGet("count/all")]
        public async Task<IActionResult> CountAll()
        {
            var response = await _categoryManager.CountAsync();
            return CreateResult(response);
        }

        [HttpGet("count/actives")]
        public async Task<IActionResult> CountActives()
        {
            var response = await _categoryManager.CountAsync(true);
            return CreateResult(response);
        }

        [Authorize("Admin")]
        [HttpGet("count/passives")]
        public async Task<IActionResult> CountPassives()
        {
            var response = await _categoryManager.CountAsync(false);
            return CreateResult(response);
        }
    }
}
