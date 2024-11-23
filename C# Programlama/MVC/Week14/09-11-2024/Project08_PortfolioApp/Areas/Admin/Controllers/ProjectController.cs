using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Project08_PortfolioApp.Models;

namespace Project08_PortfolioApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        public async Task<ActionResult> Index()
        {
            //Bağlantıyı hazırlıyoruz
            var connectionString = "Server=localhost,1433;Database=PortfolioDb;User=sa;Password=Qwe123.,;TrustServerCertificate=true";
            var connection = new SqlConnection(connectionString);

            //Proje listesini çekiyoruz
            var queryProjects = "select * from Projects";
            var projects = await connection.QueryAsync<Project>(queryProjects);

            return View(projects);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }
    }
}
