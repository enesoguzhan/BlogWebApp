using BusinessLayer.Ioc;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc().AddFluentValidation();
builder.Services.MyService();
/* 
 Giriþ Yapýlacak Olan Controller Hangisi ?
Çýkýþ yapýlacak controller hangisi ?
kullanýýcý sisteme giriþ yaptýðýnda ne kadar süre oturum açýk kalýcak
 */
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
    {
        x.LoginPath = "/admin/Login";
        x.LogoutPath = "/admin/Logout";
        x.AccessDeniedPath = "/YetkisizGiris";
    });

// Bütün Sayfalara Yasak Koyma
builder.Services.AddControllersWithViews(x =>
{
    var Dogrulama = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    x.Filters.Add(new AuthorizeFilter(Dogrulama));

});


var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
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
