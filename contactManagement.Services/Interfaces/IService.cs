using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contactManagement.Services.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Find(int Id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int Id);
    }
}
