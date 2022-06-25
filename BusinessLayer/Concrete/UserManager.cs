namespace BusinessLayer.Concrete
{
    internal class UserManager : Repostories<Users>, IUserService
    {
        public UserManager (BlogContext db) : base(db) { }
    }
}
