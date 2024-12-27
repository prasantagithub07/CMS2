using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contactManagement.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Find(int Id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int Id);
        void SaveChanges();
    }
}
