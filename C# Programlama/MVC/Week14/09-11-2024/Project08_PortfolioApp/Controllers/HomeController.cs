using System.Data.SqlClient;
using System.Diagnostics;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Project08_PortfolioApp.Models;

namespace Project08_PortfolioApp.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        //Bağlantıyı hazırlıyoruz
        var connectionString = "Server=localhost,1433;Database=PortfolioDb;User=sa;Password=Qwe123.,;TrustServerCertificate=true";
        var connection = new SqlConnection(connectionString);

        //Site ayarlarını çekiyoruz
        var queryAppSetting = "select * from AppSettings";
        var appSetting = (await connection.QueryAsync<AppSetting>(queryAppSetting)).First();

        //Category listesini çekiyoruz
        var queryCategories = "select * from Categories";
        var categories = await connection.QueryAsync<Category>(queryCategories);

        //Project listesini çekiyoruz
        var queryProjects = "select * from Projects";
        var projects = await connection.QueryAsync<Project>(queryProjects);

        //Service listesini çekiyoruz
        var queryServices = "select * from Services";
        var services = await connection.QueryAsync<Service>(queryServices);

        //Skill listesini çekiyoruz
        var querySkills = "select * from Skills";
        var skills = await connection.QueryAsync<Skill>(querySkills);

        //Social listesini çekiyoruz
        var querySocials = "select * from Socials";
        var socials = await connection.QueryAsync<Social>(querySocials);

        HomePageModel model = new()
        {
            AppSetting = appSetting,
            Categories = categories,
            Projects = projects,
            Services = services,
            Skills = skills,
            Socials = socials
        };

        return View(model);
    }
}
