using EShop.MVC.Models;
using EShop.MVC.Services;
using EShop.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllersWithViews()
    .AddNToastNotifyToastr(new ToastrOptions()
    {
        ProgressBar = true,
        PositionClass = ToastPositions.TopRight,
        CloseButton = true,
        ShowDuration = 1000,
        HideDuration = 1000,
        TimeOut = 5000,
        ShowEasing = "swing",
        HideEasing = "linear",
        ShowMethod = "fadeIn",
        HideMethod = "fadeOut"
    });

builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.LoginPath = "/Auth/Login";
        opt.LogoutPath = "/Auth/Logout";
        opt.AccessDeniedPath = "/Auth/AccessDenied";
        opt.ExpireTimeSpan = TimeSpan.FromDays(30);
    });

builder.Services.AddHttpClient<IHttpClientService, HttpClientService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetSection("ApiSettings:BaseUri").Value!);
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "AdminRoute",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
