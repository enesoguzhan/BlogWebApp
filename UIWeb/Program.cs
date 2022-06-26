using BusinessLayer.Ioc;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc().AddFluentValidation();
builder.Services.MyService();
/* 
 Giri� Yap�lacak Olan Controller Hangisi ?
��k�� yap�lacak controller hangisi ?
kullan��c� sisteme giri� yapt���nda ne kadar s�re oturum a��k kal�cak
 */
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
    {
        x.LoginPath = "/admin/Login";
        x.LogoutPath = "/admin/Logout";
        x.AccessDeniedPath = "/YetkisizGiris";
    });

// B�t�n Sayfalara Yasak Koyma
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
