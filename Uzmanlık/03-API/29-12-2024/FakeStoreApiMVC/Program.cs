using FakeStoreApiMVC.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//ApiSettings Konfigüre Ediliyor
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("FakeStoreApi"));

//HttpClient  ApiSetting ile Konfigüre Ediliyor
builder.Services.AddHttpClient("FakeStoreApi",(serviceProvideer,client)=>
{
    ApiSettings apisettings = serviceProvideer.GetRequiredService<IOptions<ApiSettings>>().Value;
    client.BaseAddress = new Uri(apisettings.BaseUrl);
});










var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
  
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
