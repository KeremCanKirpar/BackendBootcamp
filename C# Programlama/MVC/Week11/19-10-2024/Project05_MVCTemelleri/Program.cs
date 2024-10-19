var builder = WebApplication.CreateBuilder(args);

// Bu sat�rla bir uygulaman�n bir MVC uygulamas� olaca�� bildiriliyor.
builder.Services.AddControllersWithViews();

var app = builder.Build(); // Bir web application (MVC) olu�turuluyor.

// Bu a�amadan run yap�lana kadar olan k�s�mda gelen istekler yap�land�r�l�yor.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // http �zerinden gelen istekleri https'e y�nlendirir.
app.UseStaticFiles(); // wwwroot klas�r�n�n kullan�labilir olmas�n� sa�lar.

app.UseRouting(); // Gelen isteklerin hangi controller'a gitmesi gerekti�ini belirler.

app.UseAuthorization(); // Yetkilendirme �zelliklerini aktif k�lar.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
/*https:///localhost:5100/Home/Index*/
/*https:///localhost:5100/Home*/
/*https:///localhost:5100*/


app.Run(); // Olu�turulan web application �al��t�r�l�yor.
