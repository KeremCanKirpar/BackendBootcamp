using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project08_PortfolioApp.Areas.Admin.Models;
using Project08_PortfolioApp.Models;
namespace Project08_PortfolioApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly string _folderName;
        public ProjectController(IWebHostEnvironment webHostEnvironment)
        {
            _folderName = webHostEnvironment.WebRootPath + "/ui/img/projects";
        }
        // GET: ProjectController
        public async Task<ActionResult> Index()

        {
            //Bağlantıyı hazırlıyoruz
            var connectionString = "Server=localhost,1441;Database=PortfolioDb;User=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=true";
            var connection = new SqlConnection(connectionString);

            //Site ayarlarını çekiyoruz
            var queryProjects = "select * from Projects";
            var projects = (await connection.QueryAsync<Project>(queryProjects));
            return View(projects);

        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            AddProjectViewModel model = new()
            {
                CategoryList = await GetCategoryList()

            };
            return View(model);

        }
        [HttpPost]
        public async Task<ActionResult> Create(AddProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Burada öncelikle resim yükleme işlemi yapılır. İlerde Göreceğiz.
                //Şimdilik Yüklendiğini varsayarak ImageUrl'e varsayılan bir resmin urlsini yazacağız.
                //GEÇİCİ OLARAK RESİM YÜKLEME OPERASYONU
                if (model.Image == null)
                {
                    model.CategoryList = await GetCategoryList();
                    return View(model);
                }
                if(model.Image.Length ==0)
                {
                    model.CategoryList = await GetCategoryList();
                    return View(model);
                }
                string[] correctExtensions = [".png",".jpg",".jpeg"];
                string fileExtension = Path.GetExtension(model.Image.FileName).ToLower();
                if(!correctExtensions.Contains(fileExtension))
                {
                    model.CategoryList = await GetCategoryList();
                    return View(model);
                }
                string imageFileName = $"{Guid.NewGuid()}{fileExtension}";
                string targetFolder = _folderName +"/" + imageFileName;
                await using(var stream = new FileStream(targetFolder,FileMode.Create)){
                    await stream.CopyToAsync(stream);
                }



                model.ImageUrl = "http://localhost:5100/ui/img/projects/" + imageFileName;
                var query = @"
                Insert Into Projects(Name,Description,CategoryId,GithubUrl,IsActive,ImageUrl)
                
                Values(@Name,@Description,@CategoryId,@GithubUrl,@IsActive,@ImageUrl)
                
                
                ";
                var connectionString = "Server=localhost,1441;Database=PortfolioDb;User=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=true";
                var connection = new SqlConnection(connectionString);
                await connection.ExecuteAsync(query, model);
                return RedirectToAction("Index");

            }
            model.CategoryList = await GetCategoryList();
            return View(model);
        }

        [NonAction]
        private async Task<List<SelectListItem>> GetCategoryList()
        {
            //Bağlantıyı hazırlıyoruz
            var connectionString = "Server=localhost,1441;Database=PortfolioDb;User=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=true";
            var connection = new SqlConnection(connectionString);

            //Site ayarlarını çekiyoruz
            var queryCategories = "select * from Categories";
            var categories = (await connection.QueryAsync<Category>(queryCategories));
            List<SelectListItem> result = [];
            foreach (var category in categories)
            {
                result.Add(new SelectListItem
                {
                    Text = category.Name,
                    Value = category.Id.ToString()
                });

            }
            return result;
        }
    }
}
