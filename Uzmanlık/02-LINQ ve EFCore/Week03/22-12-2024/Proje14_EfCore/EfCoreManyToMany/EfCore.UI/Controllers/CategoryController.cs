using EfCore.Business.Abstract;
using EfCore.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;         
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<ActionResult> Index()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            if(categories==null)
            {
                categories = new List<CategoryDto>();
            }
            return View(categories);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CategoryCreateDto categoryCreateDto)
        {
            if(ModelState.IsValid)
            {
               var result = await _categoryService.CreateAsync(categoryCreateDto);
                if(result==null)
                {
                    ViewBag.Message = "Bir Hata Oluştu";
                }
                else
                {
                    ViewBag.Message = "İşlem Başarıyla Tamamlandı";
                }
                return RedirectToAction("Index");
            }
            return View(categoryCreateDto);
        }
    }
}
