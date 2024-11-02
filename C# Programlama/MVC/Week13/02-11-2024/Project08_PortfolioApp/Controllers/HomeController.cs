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
        // Bağlantıyı Hazırlıyoruz
        var connectionString="Server=localhost,1441;Database=PortfolioDb;User=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=true";
        var connection = new SqlConnection(connectionString);

        //AppSettings listesini çekiyoruz
        var queryAppSetting = "Select * from AppSettings";
        var appsetting = (await connection.QueryAsync<AppSetting>(queryAppSetting)).First();
        
        //Category Listesini Çekiyoruz
        var queryCategory = "Select * from Categories";
        var categories = (await connection.QueryAsync<Category>(queryCategory));

        //Social Listesini Çekiyoruz
        var querySocials = "Select * from Socials";
        var socials = await connection.QueryAsync<Social>(querySocials);

        //Services Listesini Çekiyoruz
        var queryServices = "Select * from Services";
        var services = await connection.QueryAsync<Service>(queryServices);

        //Skill Listesini Çekiyoruz
        var querySkills = "Select * from Skills";
        var skills = await connection.QueryAsync<Skill>(querySkills);

        //Project Listesini Çekiyoruz
        var queryProjects = "Select * from Projects";
        var projects = await connection.QueryAsync<Project>(queryProjects);

        HomePageModel pageModel = new(){
            AppSetting = appsetting,
            Services = services,
            Skills = skills,
            Projects = projects,
            Socials = socials,
            Category = categories
        };

        return View(pageModel);
    }
}
