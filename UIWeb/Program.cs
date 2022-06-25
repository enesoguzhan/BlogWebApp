using BusinessLayer.Ioc;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.MyService();
/* 
 Giriþ Yapýlacak Olan Controller Hangisi ?
Çýkýþ yapýlacak controller hangisi ?
kullanýýcý sisteme giriþ yaptýðýnda ne kadar süre oturum açýk kalýcak
 */
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(s =>
    {
        s.LoginPath = "/admin/login"; // Giriþ iþlemi yapýlacak controller
        s.LogoutPath = "/admin/logout"; // Çýkýþ iþlemi yapýcak controller
        s.AccessDeniedPath = "/YetkisizGiris"; // Yetkisi olmayan giriþ yapýldýðýnda
        s.ExpireTimeSpan = TimeSpan.FromHours(1); // Giriþ geçerlilik süresi
        s.SlidingExpiration = true; // Pencere kapatýldýðýnda 
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
