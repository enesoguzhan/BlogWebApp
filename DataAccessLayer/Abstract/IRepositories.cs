using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    // where TEntity : class => TEntity tipinin dinamik bir class olacağını belirtip kısıtlıyoruz.
    public interface IRepositories<TEntity> where TEntity : class
    {
        public string Insert(TEntity entity)
        {
            return "";
        }
        public string Update(TEntity entity)
        {
            return "";
        }
        public string Delete(Expression<Func<TEntity, bool>> where);
        public IList<TEntity> GetAllList(params Expression<Func<TEntity, object>>[] inculude);
        public TEntity GetById(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] inculude);
    }
}
