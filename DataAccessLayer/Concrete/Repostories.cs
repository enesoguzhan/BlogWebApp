using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Repostories<TEntitiy> : IRepositories<TEntitiy> where TEntitiy : class
    {
        private readonly BlogContext db;
        public Repostories(BlogContext db)
        {
            this.db = db;
        }

        public string Delete(Expression<Func<TEntitiy, bool>> where)
        {
            try
            {
                db.Remove(GetById(where));
                db.SaveChanges();
                return "İşlem Başarılı";
            }
            catch (Exception)
            {
                return "İşlem Başarısız.";
            }
        }

        public IList<TEntitiy> GetAllList(params Expression<Func<TEntitiy, object>>[] inculude)
        {
            // IList,list,collection,IEnumerable gibi yapılar kullanıldıgında bütün datalar client in ram belleğine aktarılır ve sonra where şartına bakılıp data ekranını yansıtılır.
            //IQueryable kullanıldıgı zaman where şartına sql serverde baklır, şartlanmış veri kullanıcının ram belleğine aktarılıp ekrana yansıtılır.

            IQueryable<TEntitiy> queryable = db.Set<TEntitiy>();

            if (inculude.Any()) //İlişkili tablo istenmişmi bakılıyor.
            {
                foreach (var item in inculude) // Varsa Tabloya bakılıyor.
                {
                    queryable = queryable.Include(item);
                }
            }
            return queryable.ToList();
        }

        public TEntitiy GetById(Expression<Func<TEntitiy, bool>> where, params Expression<Func<TEntitiy, object>>[] inculude)
        {
            IQueryable<TEntitiy> query;
            if (where != null)
            {
                query = db.Set<TEntitiy>().Where(where);
            }
            else
            {
                query = db.Set<TEntitiy>();
            }
            if (inculude.Any()) //İlişkili tablo istenmişmi bakılıyor.
            {
                foreach (var item in inculude) // Varsa Tabloya bakılıyor.
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault();

        }
        public string Insert(TEntitiy entitiy)
        {
            try
            {
                db.Add(entitiy);
                db.SaveChanges();

                return "İşlem Başarılı";
            }
            catch (Exception)
            {

                return "İşlem Başarısız";
            }
        }

        public string Update(TEntitiy entitiy)
        {
            try
            {
                db.Update(entitiy);
                db.SaveChanges();

                return "İşlem Başarılı";
            }
            catch (Exception)
            {

                return "İşlem Başarısız";
            }
        }
    }
}
