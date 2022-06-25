using BusinessLayer.Concrete;
using BusinessLayer.ValidationFluent;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Ioc
{
    //Inversion Of Control
    public static class Containers
    {
        public static IServiceCollection MyService(this IServiceCollection services)
        {
            services.AddDbContext<BlogContext>();
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<IInteractionsService, InterActionManager>();
            services.AddScoped<IUserService, UserManager>();


            //Data doğrulamalar herkes için aynı oldugu için bir defa türetilmesi yeterlidir.
            services.AddSingleton<IValidator<Blogs>, ValidationBlogs>();
            services.AddSingleton<IValidator<Comments>, ValidationComment>();
            services.AddSingleton<IValidator<Users>, ValidationUsers>();

            return services;
        }
    }
}
