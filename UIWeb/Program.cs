using BusinessLayer.Ioc;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.MyService();
/* 
 Giri� Yap�lacak Olan Controller Hangisi ?
��k�� yap�lacak controller hangisi ?
kullan��c� sisteme giri� yapt���nda ne kadar s�re oturum a��k kal�cak
 */
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(s =>
    {
        s.LoginPath = "/admin/login"; // Giri� i�lemi yap�lacak controller
        s.LogoutPath = "/admin/logout"; // ��k�� i�lemi yap�cak controller
        s.AccessDeniedPath = "/YetkisizGiris"; // Yetkisi olmayan giri� yap�ld���nda
        s.ExpireTimeSpan = TimeSpan.FromHours(1); // Giri� ge�erlilik s�resi
        s.SlidingExpiration = true; // Pencere kapat�ld���nda 
    });

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(s =>
{
    s.MapDefaultControllerRoute();
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.Run();
