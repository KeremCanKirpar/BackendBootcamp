var builder = WebApplication.CreateBuilder(args);

// Bu satýrla bir uygulamanýn bir MVC uygulamasý olacaðý bildiriliyor.
builder.Services.AddControllersWithViews();

var app = builder.Build(); // Bir web application (MVC) oluþturuluyor.

// Bu aþamadan run yapýlana kadar olan kýsýmda gelen istekler yapýlandýrýlýyor.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // http üzerinden gelen istekleri https'e yönlendirir.
app.UseStaticFiles(); // wwwroot klasörünün kullanýlabilir olmasýný saðlar.

app.UseRouting(); // Gelen isteklerin hangi controller'a gitmesi gerektiðini belirler.

app.UseAuthorization(); // Yetkilendirme özelliklerini aktif kýlar.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
/*https:///localhost:5100/Home/Index*/
/*https:///localhost:5100/Home*/
/*https:///localhost:5100*/


app.Run(); // Oluþturulan web application çalýþtýrýlýyor.
