namespace BusinessLayer.Concrete
{
    public class CommentManager : Repostories<Comments>,ICommentService
    {
        public CommentManager(BlogContext db) : base(db) { }
    }
}
