
namespace BusinessLayer.Concrete
{
    public class BlogManager : Repostories<Blogs>, IBlogService
    {
        public BlogManager(BlogContext db) : base(db) { }
    }
}
