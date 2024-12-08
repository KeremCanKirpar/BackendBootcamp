using System.Data;
using LearnifyStockApp.Models.Repositories;
using LearnifyStockApp.Models.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LearnifyStockApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ActionResult> Index(bool id)
        {
            bool isDeleted = id;
            ViewBag.IsDeleted = isDeleted;
            var categories = await _categoryRepository.GetAllAsync(isDeleted);
            return View(categories);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.AddAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public async Task<ActionResult> Edit(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            var model = new UpdateCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                UpdatedAt = category.UpdatedAt
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UpdateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<ActionResult> SoftDelete(int id)
        {
            var isDeleted = await _categoryRepository.SoftDeleteAsync(id);
            return RedirectToAction("Index", new { id = isDeleted });
        }

        public async Task<ActionResult> HardDelete(int id)
        {
            await _categoryRepository.HardDeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
