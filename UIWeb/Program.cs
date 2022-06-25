using BusinessLayer.Ioc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.MyService();
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
