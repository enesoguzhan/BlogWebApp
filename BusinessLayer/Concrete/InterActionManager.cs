namespace BusinessLayer.Concrete
{
    internal class InterActionManager : Repostories<Interactions>, IInteractionsService
    {
        public InterActionManager(BlogContext db) : base(db) { }
    }
}
